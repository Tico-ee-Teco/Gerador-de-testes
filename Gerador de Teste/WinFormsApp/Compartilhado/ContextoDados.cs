
using Microsoft.Win32;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace FestasInfantis.WinApp.Compartilhado
{
    public class ContextoDados
    {
        //public List<Cliente> Clientes { get; set; }
        //public List<Tema> Temas { get; set; }
        //public List<Item> Items { get; set; }

        private string caminho = $"C:\\temp\\fetasInfantis\\dados.json";

        //public ContextoDados()
        //{
        //    Clientes = new List<Cliente>();

        //    Temas = new List<Tema>();

        //    Items = new List<Item>();
        //}

        //public ContextoDados(bool carregarDados) : this()
        //{
        //    if (carregarDados)
        //        CarregarDados();
        //}

        //public void Gravar()
        //{
        //    FileInfo arquivos = new FileInfo(caminho);

        //    arquivos.Directory.Create();

        //    JsonSerializerOptions options = new JsonSerializerOptions()
        //    {
        //        WriteIndented = true,
        //        ReferenceHandler = ReferenceHandler.Preserve
        //    };

        //    byte[] registrosEmBytes = JsonSerializer.SerializeToUtf8Bytes(this, options);

        //    File.WriteAllBytes(caminho, registrosEmBytes);
        //}

        //protected void CarregarDados()
        //{
        //    FileInfo arquivo = new FileInfo(caminho);

        //    if (!arquivo.Exists)
        //        return;

        //    byte[] registrosEmBytes = File.ReadAllBytes(caminho);

        //    JsonSerializerOptions options = new JsonSerializerOptions()
        //    {
        //        ReferenceHandler = ReferenceHandler.Preserve
        //    };

        //    ContextoDados ctx = JsonSerializer.Deserialize<ContextoDados>(registrosEmBytes, options);

        //    if(ctx == null) return;

        //    Clientes = ctx.Clientes;
        //    Temas = ctx.Temas;
        //    Items = ctx.Items;

        //}


    }
}
