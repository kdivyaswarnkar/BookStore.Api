using BookStore.Api.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Repository
{
   public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        Task<string> LoginAsync(SignInModel signInModel);
    }
}
