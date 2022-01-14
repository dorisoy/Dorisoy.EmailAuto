using Dorisoy.EmailAuto.Model;
using System.Threading.Tasks;

namespace Dorisoy.EmailAuto.Repositories.Interface
{
    /// <summary>
    /// Setting Repository Interface
    /// </summary>
    public interface ISettingRepository
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>Settings Model</returns>
        Task<SettingsModel> Get();

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task Add(SettingsModel model);

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task Edit(SettingsModel model);
    }
}
