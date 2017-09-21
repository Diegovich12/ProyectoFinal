using System;
using System.Threading;
using System.Windows.Forms;
using ProyectoNutrical.Models;

namespace ProyectoNutrical
{
    public partial class FormLogIn : Form
    {
        public FormLogIn()
        {
            InitializeComponent();
        }

        public Thread NuevoHilo { get; private set; }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            var pELogin = new ModelLogin
            {
                Usuario = txtUsuario.Text.Trim(),
                Password = txtContraseña.Text.Trim()
            };
            if (ModelLogin.LogIn(pELogin) > 0)
            {
                MessageBox.Show(@"Bienvenido", @"Sesión Iniciada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NuevoForm(ModelLogin.LogIn(pELogin));
            }
            else
            {
                MessageBox.Show(@"Contraseña o Usuario Incorrectos", @"Error!!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public void NuevoForm(int pPuesto)
        {
            //este se llama operador ternario 
            NuevoHilo = pPuesto == 2 ? new Thread(RunAnalista) : new Thread(RunOperador);
            Close();
            NuevoHilo.SetApartmentState(ApartmentState.STA);
            NuevoHilo.Start();
        }

        public static void RunOperador()
        {
            var frm = new FormOperador();
            frm.ShowDialog();
        }

        public static void RunAnalista()
        {
            var frm = new FormAnalista();
            frm.ShowDialog();
        }
    }
}