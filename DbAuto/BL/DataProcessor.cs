using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.IO;
using BL.DateParser;
using DAL.Repositories;
using DAL.Models;


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
            Console.WriteLine("prosses begin");
            task.Start();
        }

        private void ProcessingTask(object filePath)
        {

                CsvParser csvParser = new CsvParser((string)filePath, Delimiter);
            
                IRepository<ClientDTO> clientRepository = new ClientRepository();
                IRepository<ManagerDTO> managerRepository = new ManagerRepository();
                IRepository<GoodsDTO> goodsRepository = new GoodsRepository();
                IRepository<SalesDTO> salesRepository = new SalesRepository();

                var managerSecondName = Path.GetFileName((string)filePath).Split(new char[] { '_' })[0];

                var manager = managerRepository.Items.FirstOrDefault(x => x.SecondName.ToLower() == managerSecondName.Trim().ToLower());
                if (manager == null)
                {
                    manager = new ManagerDTO() { FirstName = managerSecondName, 
                        SecondName = managerSecondName };

                    managerRepository.Add(manager);
                    managerRepository.SaveSales();
                }
         
                var rows = csvParser.GetRecords().Select(r => new ImportedDataRow() { Date = DateTime.ParseExact(r[0],
                    "ddMMyyyy", null), Client = r[1], Goods = r[2], Total = double.Parse(r[3]) });

                foreach (var r in rows)
                {
                    lock (syncObj)
                    {
                        var c = clientRepository.Items.FirstOrDefault(x => x.Name.ToLower() == r.Client.Trim().ToLower());
                        var g = goodsRepository.Items.FirstOrDefault(x => x.Name.ToLower() == r.Goods.Trim().ToLower());
                        if (c == null)
                        {
                            clientRepository.Add(new ClientDTO() { Name = r.Client });
                            clientRepository.SaveSales();
                        }

                        if (g == null)
                        {
                            goodsRepository.Add(new GoodsDTO() { Name = r.Goods });
                            goodsRepository.SaveSales();
                        }

                        salesRepository.Add(new SalesDTO(r.Date, 
                            clientRepository.Items.FirstOrDefault(x => x.Name == r.Client).Id, 
                            goodsRepository.Items.FirstOrDefault(x => x.Name == r.Goods).Id, 
                            managerRepository.Items.FirstOrDefault(x => x.FirstName == managerSecondName).Id, 
                            r.Total));
                       Console.WriteLine("Save Changes to base");
                        salesRepository.SaveSales();
                    }
                }
          
           

         }





        }

    
}
