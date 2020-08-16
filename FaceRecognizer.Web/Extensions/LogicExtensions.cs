using FaceRecognizer.DataAccess.Database;
using FaceRecognizer.DataAccess.Repositories;
using FaceRecognizer.Models;
using FaceRecognizer.Models.Entities;
using System.Linq;
using System.Web;

namespace FaceRecognizer.Web.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class LogicExtensions
    {
        /// <summary>
        /// Sets current authenticated user id to the operation input parameter.
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static TInput Authorized<TInput>(this TInput input) where TInput : LogicInput, new()
        {
            TInput parameter = input ?? new TInput();
            try
            {
                string tokenString = HttpContext.Current.Request.Headers.GetValues("token").First();
                Token token = new Repository<Token>(new MyDbContext()).Get(x => x.Value == tokenString);
                parameter.CurrentUserId = token.UserId;
            }
            catch { }
            return parameter;
        }
    }
}
