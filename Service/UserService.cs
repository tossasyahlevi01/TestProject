using Microsoft.EntityFrameworkCore;
using TestProject.DTO;
using TestProject.Entity;
using TestProject.Helper;
using TestProject.Insfrastructure;
using TestProject.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestProject.Service
{
    public class UserService : DBStructures, IUser
    {
        private IHelper _LogicHelper { get; set; }
        public UserService (IHelper LogicHelper)
        {
            _LogicHelper = LogicHelper;
        }
        public async Task<(bool Error, GeneralResponses GetUser)> Logon(UserLogonDTO Entity)
        {
        
            try
            {
                if(Entity.Username== "SKYWORXAPIAccess" && Entity.Password== "SKYWORX123456")
                {
                    var GetToken = await _LogicHelper.GenerateToken2(Entity);
                    var Return = new GeneralResponses()
                    {
                        Authenticated = true,
                        IsError = false,
                        Message = "OK",
                        Content = new GeneralContent()
                        {
                            Token = GetToken.Token
                        }
                    };
                    return (false, Return);
                }
                else
                {
                    if (Entity.Username != "SKYWORXAPIAccess")
                    {
                        var Return = new GeneralResponses()
                        {
                            Authenticated = false,
                            IsError = true,
                            Message = "Invalid Access, Username Invalid, Authenticated False"
                        };
                        return (true,Return);
                    }
                    if(Entity.Password != "SKYWORX123456")
                    {
                        var Return = new GeneralResponses()
                        {
                            Authenticated = false,
                            IsError = true,
                            Message = "Invalid Access, Password Invalid, Authenticated False"
                        };
                        return (true, Return);

                    }
                    else
                    {
                        var Return = new GeneralResponses()
                        {
                            Authenticated = false,
                            IsError = true,
                            Message = "User not Found"
                        };
                        return (true, Return);
                    }

                }
            }
            catch (Exception ex)
            {
                var Return = new GeneralResponses()
                {
                    Message = ex.Message,
                    IsError = true
                };
                return (Return.IsError, Return);
            }
        }

                public async Task<(bool Error, GeneralResponses GetUser)> listUser()
        {
            try
            {
                var Data =await  users.Select(es => new UserDTO
                {
                    UserID = es.userid,
                    Name = es.name,
                    NIP = es.nip,
                    Branch = es.branch,
                    role = es.role,
                    NoHP = es.nohp
                }).ToListAsync();
                var Return = new GeneralResponses()
                {
                    Message = "OK",
                    IsError = false,
                    Content = new GeneralContent()
                    {
                        ListUser=Data
                    }
                };
                return (Return.IsError,Return);
            }
            catch(Exception ex)
            {
                var Return = new GeneralResponses()
                {
                    Message=ex.Message,
                    IsError=true
                };
                return (Return.IsError, Return);
            }
        }


        public async Task<(bool Error, GeneralResponses GetUser)> InsertUser(UserDTO Entity)
        {
            try
            {
                var Data = new Users()
                {
                    userid=Entity.UserID,
                    name=Entity.Name,
                    nohp=Entity.NoHP,
                    nip=Entity.NIP,
                    branch=Entity.Branch,
                    role=Entity.role
                };

                await users.AddAsync(Data);
                await SaveChangesAsync();

                var Return = new GeneralResponses()
                {
                    Message = "OK",
                    IsError = false,
                    Content = new GeneralContent()
                    {

                    Detail= new DetailContent()
                    {
                        Message="Data Is Inserted",
                        IsError=false
                    }

                    }
                };
                return (Return.IsError, Return);
            }
            catch (Exception ex)
            {
                var Return = new GeneralResponses()
                {
                    Message = ex.Message,
                    IsError = true
                };
                return (Return.IsError, Return);

            }
        }

        public async Task<(bool Error, GeneralResponses GetUser)> DeleteUser(string UserId)
        {
            try
            {
                var CekData = await users.Where(es => es.userid == UserId).AnyAsync();
                if (CekData == true)
                {
                    var Data = await users.Where(es => es.userid == UserId).FirstOrDefaultAsync();
                    users.Remove(Data);
                    await SaveChangesAsync();
                    var Return = new GeneralResponses()
                    {
                        Message = "OK",
                        IsError = false,
                        Content = new GeneralContent()
                        {

                            Detail = new DetailContent()
                            {
                                Message = "Data Is Deleted",
                                IsError = false
                            }

                        }
                    };
                    return (Return.IsError, Return);
                }
                else
                {
                    var Return = new GeneralResponses()
                    {
                        Message = "Error",
                        IsError = true,
                        Content = new GeneralContent()
                        {

                            Detail = new DetailContent()
                            {
                                Message = "Data Not Found",
                                IsError = false
                            }

                        }
                    };
                    return (Return.IsError, Return);
                }
            }
            catch (Exception ex)
            {
                var Return = new GeneralResponses()
                {
                    Message = ex.Message,
                    IsError = true
                };
                return (Return.IsError, Return);
            }
        }

                public async Task<(bool Error, GeneralResponses GetUser)> UpdateUser(UserDTO Entity)
        {
            try
            {
                var CekData = await users.Where(es => es.userid == Entity.UserID).AnyAsync();
                if(CekData==true)
                {

                    var Data = new Users()
                    {
                        userid = Entity.UserID,
                        name = Entity.Name,
                        nohp = Entity.NoHP,
                        nip = Entity.NIP,
                        branch = Entity.Branch,
                        role = Entity.role
                    };

                    Entry(Data).State = EntityState.Modified;

                    await SaveChangesAsync();
                    var Return = new GeneralResponses()
                    {
                        Message = "OK",
                        IsError = false,
                        Content = new GeneralContent()
                        {

                            Detail = new DetailContent()
                            {
                                Message = "Data Is Updated",
                                IsError = false
                            }

                        }
                    };
                    return (Return.IsError, Return);
                }
                else
                {
                    var Return = new GeneralResponses()
                    {
                        Message = "Error",
                        IsError = true,
                        Content = new GeneralContent()
                        {

                            Detail = new DetailContent()
                            {
                                Message = "Data Not Found",
                                IsError = false
                            }

                        }
                    };
                    return (Return.IsError, Return);
                }


               
            }
            catch (Exception ex)
            {
                var Return = new GeneralResponses()
                {
                    Message = ex.Message,
                    IsError = true
                };
                return (Return.IsError, Return);

            }
        }
        public async Task<(bool Error, GeneralResponses GetUser)> GetDetailUser(string UserId)
        {
            try
            {
                var GetData = await users.Where(es => es.userid==UserId).AnyAsync();

                if (GetData == true)
                {
                    var Data = await users.Select(es => new UserDTO
                    {
                        UserID = es.userid,
                        Name = es.name,
                        NIP = es.nip,
                        Branch = es.branch,
                        role = es.role,
                        NoHP = es.nohp
                    }).Where(es => es.UserID == UserId).FirstOrDefaultAsync();
                    var Return = new GeneralResponses()
                    {
                        Message = "OK",
                        IsError = false,
                        Content = new GeneralContent()
                        {

                            DetailUser = Data

                        }
                    };
                    return (Return.IsError, Return);
                }
                else
                {
                    var Return = new GeneralResponses()
                    {
                        Message = "OK",
                        IsError = false,
                        Content = new GeneralContent()
                        {

                            Detail=new DetailContent()
                            {
                                Message="User Not Found",
                                IsError=false
                            }

                        }
                    };
                    return (Return.IsError, Return);

                }
            }
            catch (Exception ex)
            {
                var Return = new GeneralResponses()
                {
                    Message = ex.Message,
                    IsError = true
                };
                return (Return.IsError, Return);
            }
        }


    }
}
