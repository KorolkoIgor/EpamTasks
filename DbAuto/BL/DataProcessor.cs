using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.IO;
using BL.DateParser;
using DAL.Repositories;


namespace BL
{
    public class DataProcessor
    {
        private char[] Delimiter { get; set; }
        private object syncObj = new object();

        public DataProcessor(char[] delimiter)
        {
            Delimiter = delimiter;
        }

        public void StartProcessing(string filePath)
        {
            Task task = new Task(ProcessingTask, filePath);
            task.Start();
        }

        private void ProcessingTask(object filePath)
        {
            CsvParser csvParser = new CsvParser((string)filePath, Delimiter);

           
            IRepository<DAL.Models.Client> clientRepository = new ClientRepository();
            IRepository<DAL.Models.Manager> managerRepository = new ManagerRepository();
            IRepository<DAL.Models.Goods> goodsRepository = new GoodsRepository();
            IRepository<DAL.Models.Sales> salesRepository = new SalesRepository();

            var managerSecondName = Path.GetFileName((string)filePath).Split(new char[] { '_' })[0];

            var manager = managerRepository.Items.FirstOrDefault(x => x.SecondName.ToLower() == managerSecondName.Trim().ToLower());
            if (manager == null)
            {
                manager = new DAL.Models.Manager() { FirstName = managerSecondName, SecondName = managerSecondName };
               
                    managerRepository.Add(manager);
                     managerRepository.SaveChanges();
                //}

               // return;
            }

            var rows = csvParser.GetRecords().Select(r => new ImportedDataRow() { Date = DateTime.ParseExact(r[0], "ddMMyyyy", null), Client = r[1], Goods = r[2], Total = double.Parse(r[3]) });

            foreach (var r in rows)
            {
                lock (syncObj)
                {
                    var c = clientRepository.Items.FirstOrDefault(x => x.Name.ToLower() == r.Client.Trim().ToLower());
                    var g = goodsRepository.Items.FirstOrDefault(x => x.Name.ToLower() == r.Goods.Trim().ToLower());
                    if (c == null)
                    {
                        clientRepository.Add(new DAL.Models.Client() { Name = r.Client });
                        clientRepository.SaveChanges();
                    }

                    if (g == null)
                    {
                        goodsRepository.Add(new DAL.Models.Goods() { Name = r.Goods });
                        goodsRepository.SaveChanges();
                    }

                    salesRepository.Add(new DAL.Models.Sales()
                    {
                        Date = r.Date,
                        ManagerId = manager.Id,
                        ClientId = clientRepository.Items.FirstOrDefault(x => x.Name == r.Client).Id,
                        GoodsId = goodsRepository.Items.FirstOrDefault(x => x.Name == r.Goods).Id,
                        Cost = r.Total
                    });
                    salesRepository.SaveChanges();
                }
            }
        }
    }
}
