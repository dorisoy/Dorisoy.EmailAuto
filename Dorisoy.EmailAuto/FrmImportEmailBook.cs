using Dorisoy.EmailAuto.Repositories.Interface;
using Dorisoy.EmailAuto.ViewModel;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dorisoy.EmailAuto
{
    /// <summary>
    /// Import Email Book Form
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class FrmImportEmailBook : Form
    {
        private readonly IEmailBookRepository _emailBookRepository;

        /// <summary>
        /// The selected rows
        /// </summary>
        public DataGridViewSelectedRowCollection SelectedRows;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmImportEmailBook"/> class.
        /// </summary>
        /// <param name="emailBookRepository">The email book repository.</param>
        public FrmImportEmailBook(IEmailBookRepository emailBookRepository)
        {
            _emailBookRepository = emailBookRepository;
            InitializeComponent();
        }

        private async void FrmImportEmailBook_Load(object sender, EventArgs e)
        {
            await GetData();
        }

        private async Task GetData()
        {
            var data = await _emailBookRepository.Get();
            dgvEmails.DataSource = data.Select(p => new EmailViewModel
            {
                Email = p.Email,
                Name = p.Name,
                Option1 = p.Option1,
                Option2 = p.Option2,
                Option3 = p.Option3,
                Option4 = p.Option4,
                Option5 = p.Option5
            }).ToList();

            this.Text = $"Email 簿 (总共 {data?.Count})";
            this.dgvEmails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (dgvEmails.SelectedRows.Count > 0)
            {
                SelectedRows = dgvEmails.SelectedRows;
                this.Close();
            }
        }
    }
}
