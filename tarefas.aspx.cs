using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToDoList
{
    public partial class tarefas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource1_Inserted(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                LabelMensage.Text = "O Valor Não Pode Ser Repetido";
                e.ExceptionHandled = true;
            }
        }

        protected void Button_Cadastrar(object sender, EventArgs e)
        {
            string novaTarefa = textBoxTarefa.Text.Trim();

            // Verificar se o campo tarefa está vazio
            if (string.IsNullOrEmpty(novaTarefa))
            {
                LabelMensage.Text = "O campo tarefa não ser vazio.";
                LabelMensage.Visible = true;
                return;
            }

            string connString = Connection.ConnectionString;
            using (var conexao = new MySqlConnection(connString))
            {
                try
                {
                    conexao.Open();

                    // Verificar se o valor já existe no banco de dados
                    using (var verificaComando = new MySqlCommand("SELECT COUNT(*) FROM tarefas WHERE tarefa = @tarefa", conexao))
                    {
                        verificaComando.Parameters.AddWithValue("@tarefa", novaTarefa);
                        int count = Convert.ToInt32(verificaComando.ExecuteScalar());

                        if (count > 0)
                        {
                            LabelMensage.Text = "A tarefa já existe no banco de dados.";
                            LabelMensage.Visible = true;
                            return;
                        }
                    }

                    // Se não for duplicado, inserir o novo valor
                    using (var comando = new MySqlCommand("INSERT INTO tarefas (tarefa) VALUES (@tarefa)", conexao))
                    {
                        comando.Parameters.AddWithValue("@tarefa", novaTarefa);
                        comando.ExecuteNonQuery();
                    }

                    // Exibir mensagem de sucesso
                    LabelMensage.Text = "Tarefa cadastrada com sucesso!";
                    LabelMensage.Visible = true;
                }
                catch (Exception ex)
                {
                    // Tratar exceções, se necessário
                    LabelMensage.Text = "Ocorreu um erro ao cadastrar a tarefa: " + ex.Message;
                    LabelMensage.Visible = true;
                }
                finally
                {
                    // Fechar a conexão
                    conexao.Close();
                }
            }

            // Atualizar o GridView após a inserção dos dados
            BindGridView();
        }
        private void BindGridView()
        {
            // Conectar ao banco de dados e carregar os dados no GridView
            string connString = Connection.ConnectionString;
            using (var conexao = new MySqlConnection(connString))
            {
                try
                {
                    conexao.Open();
                    using (var comando = new MySqlCommand("SELECT * FROM tarefas", conexao))
                    {
                        MySqlDataAdapter da = new MySqlDataAdapter(comando);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    // Tratar exceções, se necessário
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // Fechar a conexão
                    conexao.Close();
                }
            }
        }
    }
}