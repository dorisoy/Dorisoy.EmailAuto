using Dorisoy.EmailAuto.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dorisoy.EmailAuto.Repositories.Interface
{
    /// <summary>
    /// Email Book Repository Interface
    /// </summary>
    public interface IEmailBookRepository
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        Task<List<EmailBookModel>> Get();

        /// <summary>
        /// Existses the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        Task<bool> Exists(string email);

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task Add(List<EmailBookModel> model);

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task Add(EmailBookModel model);

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task Edit(EmailBookModel model);

        /// <summary>
        /// Deletes the specified email book identifier.
        /// </summary>
        /// <param name="emailBookId">The email book identifier.</param>
        /// <returns></returns>
        Task Delete(List<int> emailBookId);
    }
}
