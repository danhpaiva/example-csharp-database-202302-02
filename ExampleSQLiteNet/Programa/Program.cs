using Microsoft.Data.Sqlite;

try
{
  using (var connection = new SqliteConnection("Data Source=C:\\banco_loja\\DB_LOJA.db"))
  {
    connection.Open();

    var command = connection.CreateCommand();
    command.CommandText =
    @"
        SELECT name
        FROM tb_user
    ";
    command.Parameters.AddWithValue("$id", 1);

    using (var reader = command.ExecuteReader())
    {
      while (reader.Read())
      {
        var name = reader.GetString(0);

        Console.WriteLine($"Hello, {name}!");
      }
    }
  }

}
catch (System.Exception erro)
{
  Console.WriteLine($"Deu um erro no banco: {erro.Message}");
}
finally
{
  Console.ReadLine();
}