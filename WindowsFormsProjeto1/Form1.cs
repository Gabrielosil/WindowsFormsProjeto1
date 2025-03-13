using System.ComponentModel;

namespace WindowsFormsProjeto1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidaNome(txtNome.Text))
                MessageBox.Show("Nome inválido");
            //Remove os pontos e traços da máscara,
            //para ler somente o
            //valor que o usuário digitou
             
            if (!ValidaCpf(txtCPF.Text))
                MessageBox.Show("CPF Inválido");
           
        }

        private bool ValidaNome(string nome)
        {
            if (nome == null || nome.Trim() == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool ValidaCpf(string cpf) 
        {
            cpf = cpf.Remove(3,1);
            cpf = cpf.Remove(6,1);
            cpf = cpf.Remove(9, 1);
            if (cpf == null || cpf.Trim() == "" || cpf.Length!= 11)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void txtPaís_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                MessageBox.Show("Apertou o Enter");
            }
        }
    }
}
