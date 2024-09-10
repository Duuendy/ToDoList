using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToDoList
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGridView();
            }

        }
        protected void LoadGridView()
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
                        grdTarefas.DataSource = dt;
                        grdTarefas.DataBind();
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

        protected void Finalizado_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            HiddenField hiddenField = (HiddenField)checkBox.Parent.FindControl("TarefaHiddenField");

            string connString = Connection.ConnectionString;
            using (var conexao = new MySqlConnection(connString))
            {
                conexao.Open();

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexao; // Atribuir a conexão ao comando
                    comando.CommandType = CommandType.Text;

                    if (checkBox.Checked)
                    {
                        comando.CommandText = "UPDATE tarefas SET finalizado = 1 WHERE id = @id";
                    }
                    else
                    {
                        comando.CommandText = "UPDATE tarefas SET finalizado = 0 WHERE id = @id";
                    }

                    // Adicionar o parâmetro para evitar SQL Injection
                    comando.Parameters.AddWithValue("@id", hiddenField.Value);

                    comando.ExecuteNonQuery();
                }

                conexao.Close();
            }
            // Rebind GridView para refletir as mudanças
            BindGridView();
        }

        private void BindGridView()
        {
            string connString = Connection.ConnectionString;

            using (var conexao = new MySqlConnection(connString))
            {
                conexao.Open();

                using (var comando = new MySqlCommand("SELECT id, tarefa FROM tarefas", conexao))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(comando);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    grdTarefas.DataSource = dt;
                    grdTarefas.DataBind();
                }

                conexao.Close();
            }
        }

        
        protected void Button_Deletar(object sender, EventArgs e)
        {
            string connString = Connection.ConnectionString;

            using (var conexao = new MySqlConnection(connString))
            {
                conexao.Open();

                foreach (GridViewRow row in grdTarefas.Rows)
                {
                    CheckBox chkDel = (CheckBox)row.FindControl("chkDel");

                    if (chkDel != null && chkDel.Checked)
                    {
                        int tarefaId = Convert.ToInt32(row.Cells[1].Text);

                        using (var comando = new MySqlCommand("DELETE FROM tarefas WHERE id = @ID", conexao))
                        {
                            comando.Parameters.AddWithValue("@ID", tarefaId);
                            comando.ExecuteNonQuery();
                        }
                    }
                }

                conexao.Close();
            }

            // Recarregar o GridView após deletar
            BindGridView();
        }

        protected void Button_Editar(object sender, EventArgs e)
        {
            string connString = Connection.ConnectionString;

            using (var conexao = new MySqlConnection(connString))
            { 
                conexao.Open();

                foreach (GridViewRow row in grdTarefas.Rows)
                {
                    CheckBox chkSelect = (CheckBox)row.FindControl("chkDel");
                    if (chkSelect != null && chkSelect.Checked)
                    {
                        int id = int.Parse(row.Cells[1].Text);       
                        {
                            using (var comando = new MySqlCommand("UPDATE tarefas SET tarefa = @Tarefa WHERE id = @Id", conexao))
                            {
                                comando.Parameters.AddWithValue("@Tarefa", txtAlterTarefa.Text);
                                comando.Parameters.AddWithValue("@Id", id);
                                
                                comando.ExecuteNonQuery();
                                
                            }
                        }
                    }
                }
                conexao.Close();
            }
            // Recarregar o GridView após atualizar
            BindGridView();
        }
    }

}