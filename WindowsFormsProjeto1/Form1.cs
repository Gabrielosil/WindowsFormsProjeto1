using CadastroAlunos;
using System.ComponentModel;
using WindowsFormsProjeto1.Model;

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
            /*
            if (!ValidaNome(txtNome.Text))
                MessageBox.Show("Nome inv�lido");
            
            if (!ValidaCpf(txtCPF.Text))
                MessageBox.Show("CPF Inv�lido");

            if (!ValidaDataNascimento2(txtDataNascimento.Text))
                MessageBox.Show("Data de Nascimento Inv�lida");
            
            if (!ValidaEmail(txtEmail.Text))
                MessageBox.Show("Email inv�lido");
            */
            AlunoModel novoAluno = new AlunoModel();
            novoAluno.Nome = txtNome.Text;

            string cpf = txtCPF.Text.Replace("-","");
            cpf = cpf.Replace(",", "");
            novoAluno.CPF = cpf;

            novoAluno.Email = txtEmail.Text;

            string telefone = txtCelular.Text.Replace("(", "");
            telefone = telefone.Replace(")", "");
            telefone = telefone.Replace("-","");
            novoAluno.Telefone = telefone;

            novoAluno.DataNascimento = Convert.ToDateTime(txtDataNascimento.Text);

            novoAluno.NomeDaMae = txtNomeDaMae.Text;

            Random geraNumeroAleatorio = new Random();
            int numeroAleatorio = geraNumeroAleatorio.Next(1, 1000000);
            novoAluno.NumeroMatricula = numeroAleatorio.ToString();

            Database.SalvarAluno(novoAluno);
          
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
            if (cpf == null || cpf.Trim() == "" || !cpf.All(char.IsDigit) || cpf.Length!= 11)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private bool ValidaDataNascimento(string dataNascimento)
        {
            if (string.IsNullOrEmpty(dataNascimento))
                return false;

            DateTime hoje = DateTime.Today;
            DateTime nascimento = Convert.ToDateTime(dataNascimento);

            if(nascimento > hoje)
                return false;
            
            return true;
        }

        private bool ValidaDataNascimento2(string dataNascimento)
        {
            //Verifica se o valor que vem na data de nascimento � vazio ou nulo
            if (string.IsNullOrEmpty(dataNascimento))
                return false;

            //Utiliza a estrutura DateTime para buscar o valor da data de hoje e armazenar na vari�vel hoje
            DateTime hoje = DateTime.Today;
            DateTime nascimento;

            //Executa o m�todo TryParse, que tenta converter o valor dataNascimento, que � uma string
            //em uma data, caso d� sucesso, ir� armazenar o valor da dataNascimento na vari�vel nascimento.
            bool sucesso = DateTime.TryParse(dataNascimento, out nascimento);

            //Verifica se a convers�o de data foi bem sucedida e se a data de nascimento � maior que a data de hoje.
            if (!sucesso || nascimento > hoje)
                return false;
            
            return true;
        }


        private bool ValidaEmail(string email)
        {
            if (!email.Contains("@"))
                return false;

            int posicaoDoArroba = email.IndexOf("@");

            if (posicaoDoArroba > 0)
            {
                string restanteDoEmail = email.Substring(posicaoDoArroba+1);
              
                if (restanteDoEmail.Length > 1 &&
                restanteDoEmail[0] != '.' &&
                !restanteDoEmail.Contains("@") &&
                restanteDoEmail.Contains("."))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return false;

        }


        private void txtPa�s_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                MessageBox.Show("Apertou o Enter");
            }
        }
       
    }
}
