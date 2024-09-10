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

        protected void SqlDataSource1_Updated(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                LabelMensage.Text = "Informação Alterada";
                e.ExceptionHandled = true;
            }
        }

        protected void SqlDataSource1_Deleted(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                LabelMensage.Text = "Informação Deletada";
                e.ExceptionHandled = true;
            }
        }

        protected void Button_Cadastrar(object sender, EventArgs e)
        {
            // Conectar ao banco de dados e inserir os dados
            string connString = Connection.ConnectionString;
            using (var conexao = new MySqlConnection(connString))
            {
                try
                {
                    conexao.Open();
                    using (var comando = new MySqlCommand("INSERT INTO tarefas (tarefa) VALUES (@tarefa)", conexao))
                    {
                        // Adicionar parâmetros ao comando
                        //comando.Parameters.AddWithValue("@data", textBoxData.Text);
                        comando.Parameters.AddWithValue("@tarefa", textBoxTarefa.Text);

                        // Executar a inserção
                        comando.ExecuteNonQuery();
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