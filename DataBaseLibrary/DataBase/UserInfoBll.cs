//********************************************************************************************
//
// 文件名(File Name):                    UserInfoBll
//
// 作者(Author):                            LEGION
//
// 日期(Create Date):                     2023/4/10 15:18:11
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
    public class UserInfoBll
    {
        UserInfoDal userInfoDal = new UserInfoDal();
        public int GetUser(string userName, string passWord)
        {
            return userInfoDal.GetUser(userName, passWord);
        }
    }
}
