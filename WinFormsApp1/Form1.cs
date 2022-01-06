using Filmy.Data.Services;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartUpForm startUpForm = new StartUpForm();
            this.db = startUpForm;
        }

        //private readonly IMovieServices _service;
        private readonly StartUpForm db;
 
        private async void Form1_Load(object sender, EventArgs e)
        {
            var movies = db.Movie.ToList();
            dataGridView1.DataSource = movies;

            var actors = db.Actor.ToList();
            dataGridView2.DataSource = actors;
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
        }

        private void BKonec_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
