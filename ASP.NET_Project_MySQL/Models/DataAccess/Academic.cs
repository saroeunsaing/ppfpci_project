using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_Project_MySQL.Models.DataAccess
{
    public class Academic
    {
        public int Insert_Academic(string Id, string NameKH,string NameEn)
        {
            AcademicsModel data = new AcademicsModel
            {
                id = Id,
                namekh = NameKH,
                nameen = NameEn
            };
            string sql = @"INSERT INTO academics VALUES(@id,@namekh,@nameen)";
           
            return SQLControl.ExecuteData(sql, data);
        }
        public int Update_Academic(string Id, string NameKH, string NameEn)
        {
            AcademicsModel data = new AcademicsModel
            {
                id = Id,
                namekh = NameKH,
                nameen = NameEn
            };
            string sql = @"Update academics SET namekh = @namekh, nameen = @nameen WHERE id =@id";

            return SQLControl.ExecuteData(sql, data);
        }

        public bool Delete_Academic(string Id)
        {
            AcademicsModel data = new AcademicsModel
            {
                id = Id
            };
            string sql = @"DELETE FROM academics WHERE id =@id";

            SQLControl.ExecuteData(sql, data);
            return true;
        }
        public  List<AcademicsModel>loadAcademic()
        {
            string sql = @"SELECT id,namekh,nameen FROM academics";

            return SQLControl.LoadData<AcademicsModel>(sql);
            
            
        }
    }
}