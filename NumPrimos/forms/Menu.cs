namespace NumPrimos
{
    public partial class Menu : Form
    {
        
        public Menu()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GestionClientes ventanaGestionClientes = new GestionClientes();
            ventanaGestionClientes.ShowDialog();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }
        private bool esNumeroPrimo(double numero)
        {
            bool primo = true;

            for (int i = 2; i < numero; i++)
            {
                if (numero % i == 0)
                {
                    primo = false;
                    break;
                }
            }


            return primo;
        }
    }
}