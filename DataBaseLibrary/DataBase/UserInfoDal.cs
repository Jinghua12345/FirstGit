//********************************************************************************************
//
// 文件名(File Name):                    UserInfoDal
//
// 作者(Author):                            LEGION
//
// 日期(Create Date):                     2023/4/10 15:13:15
//
// 功能(Function):                         
//
// 修改记录(Revision History):
//         R1:
//********************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLibrary.DataBase
{
    public class UserInfoDal
    {
        DataBaseDbContext entity = new DataBaseDbContext();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public int GetUser(string userName, string passWord)
        {
            var users = from l in entity.UserInfo
                        where l.UserName == userName && l.PassWord == passWord
                        select l;
            return users.Count();
        }
    }
}
