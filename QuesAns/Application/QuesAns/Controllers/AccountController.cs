using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using QuesAns.Models.AccountModels;
using QuesAns.Utility;
using StackExchange.Redis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace QuesAns.Controllers
{
    public class AccountController : Controller
    {
        #region Configure
        private readonly DropdownService _dropdownService;
        private readonly IDatabase _database;

        public AccountController(DropdownService dropdownService, IDatabase database)
        {
            _dropdownService = dropdownService;
            _database = database;
        }

        #endregion

        #region Register
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var model = Startup.AutofacContainer.Resolve<UserVM>();
            model.UserTypeLookup = _dropdownService.GetUserTypeSelectListItems();
            return View(model);
        }


        [ValidateAntiForgeryToken, HttpPost]
        public async Task<IActionResult> Register(UserVM model)
        {
            await model.RegisterUser();
            return RedirectToAction("Register");
        }
        #endregion

        #region Login
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            var model = Startup.AutofacContainer.Resolve<UserVM>();
            
            return View(model);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public async Task<IActionResult> Login(UserVM model)
        {
            var userVM = new RedisDictionary<string, UserVM>(_database, "UserVM");
            var cashedData = userVM.GetCashedData(model.UserName);

            if(cashedData != null) // Need to resolve cashed login with password verification
            {
                HttpContext.Session.SetString("Id", cashedData.Id.ToString());
                HttpContext.Session.SetString("UserName", cashedData.UserName);
                HttpContext.Session.SetString("UserType", cashedData.UserType);

                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            else
            {
                model.GetLoginUser();

                if (model.Id != Guid.Empty)
                {
                    HttpContext.Session.SetString("Id", model.Id.ToString());
                    HttpContext.Session.SetString("UserName", model.UserName);
                    HttpContext.Session.SetString("UserType", model.UserType);

                    userVM.Add(model.UserName, new UserVM
                    {
                        Id = model.Id,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        InstituteName = model.InstituteName,
                        InstituteId = model.InstituteId,
                        PasswordHash = model.PasswordHash,
                        UserName = model.UserName,
                        UserType = model.UserType,
                    });

                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
        }
        #endregion
        #region Logout
        //public async Task<IActionResult> Logout(string returnUrl = null)
        //{
        //    await _signInManager.SignOutAsync();
        //    //_logger.LogInformation("User logged out.");
        //    if (returnUrl != null)
        //    {
        //        return LocalRedirect(returnUrl);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login");
        //    }
        //}
        #endregion
    }


    #region Radies Dictionary
    public class RedisDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly IDatabase _database;
        private string _redisKey;

        public RedisDictionary(IDatabase database, string redisKey)
        {
            _database = database;
            _redisKey = redisKey;
        }

        private string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        private TValue DeSerialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<TValue>(value);
        }

        public TValue this[TKey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<TKey> Keys => throw new NotImplementedException();

        public ICollection<TValue> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(TKey key, TValue value)
        {
            _database.HashSet(Serialize(key).ToString(), Serialize(key), Serialize(value));
        }

        public TValue GetCashedData(TKey key)
        {
            var value = _database.HashGet(Serialize(key).ToString(), Serialize(key)).ToString();
            return DeSerialize<TValue>(value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }




    #endregion
























































}
