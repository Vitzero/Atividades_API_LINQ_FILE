using ExerciciosHash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using static System.Runtime.InteropServices.JavaScript.JSType;


void Question1()
{
    Dictionary<string, List<int>> vendasCarros = new Dictionary<string, List<int>> {
    { "Bugatti Veyron", new List<int> { 10, 15, 12, 8, 5 } },
    { "Koenigsegg Agera RS", new List<int> { 2, 3, 5, 6, 7 } },
    { "Lamborghini Aventador", new List<int> { 20, 18, 22, 24, 16 } },
    { "Pagani Huayra", new List<int> { 4, 5, 6, 5, 4 } },
    { "Ferrari LaFerrari", new List<int> { 7, 6, 5, 8, 10 } }
    };


    foreach (var carro in vendasCarros)
    {
        int vendas = 0;
        int i = 0;
        double media = 0.0;
        foreach (var venda in carro.Value)
        {
            vendas += venda;
            i++;
        }
        media = (float)vendas / i;
        Console.WriteLine($"{carro.Key} vendeu a media de: {media:F2} por mês");
    }

    Console.WriteLine(vendasCarros["Ferrari LaFerrari"].Average());
}

static async Task QuestionDeserializes()
{
    using (HttpClient client = new HttpClient())
    {
        // JSON simples (anime quote)
        string url = "https://api.animechan.io/v1/quotes/random";
        var response = await client.GetStringAsync(url);
        Console.WriteLine("Anime Quote JSON:");
        Console.WriteLine(response);
        Console.WriteLine();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        // JSON de filmes
        string endPoint = "https://raw.githubusercontent.com/ArthurOcFernandes/Exerc-cios-C-/curso-4-aula-2/Jsons/TopMovies.json";
        string response2 = await client.GetStringAsync(endPoint);
        var filmes = JsonSerializer.Deserialize<List<Filme>>(response2, options)!;

        Console.WriteLine("---- Filmes ----");
        foreach (var item in filmes)
        {
            item.ShowDetails();
            Console.WriteLine();
        }

        // JSON de países
        string endPointPais = "https://raw.githubusercontent.com/ArthurOcFernandes/Exerc-cios-C-/curso-4-aula-2/Jsons/Paises.json";
        string jsonPais = await client.GetStringAsync(endPointPais);
        var paises = JsonSerializer.Deserialize<List<Pais>>(jsonPais, options)!;

        Console.WriteLine("---- Países ----");
        foreach (var item in paises)
        {
            item.ShowDetails();
            Console.WriteLine();
        }

        // JSON bagunçado (Character da API GOT)
        string end = "https://www.anapioficeandfire.com/api/characters/16";
        string jsonEmString = await client.GetStringAsync(end);
        var personagem = JsonSerializer.Deserialize<Character>(jsonEmString, options)!;

        Console.WriteLine("---- Personagem ----");
        personagem.ShowDetails();
    }
}

void LinqQuestion1()
{
    //Dada uma lista de números, criar uma consulta LINQ para retornar apenas os elementos únicos da lista.
        List<int> listOfNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 7, 8, 8, 9, 10, 11, 12, 12, 13, 14, 15, 16, 16 };

        var filteredListOfNumbers =
            listOfNumbers
            .Distinct()
            .ToList();

         foreach(var item in filteredListOfNumbers) { Console.WriteLine(item); }  
}

void LinqQuestion2()
{
    //Dada uma lista de livros com título, autor e ano de publicação,
    //criar uma consulta LINQ para retornar uma lista com os títulos dos livros publicados após o ano 2000, ordenados alfabeticamente.
    List<Livro> livros = new List<Livro>
        {
            new Livro { Titulo = "Dom Casmurro", Autor = "Machado de Assis", AnoPublicacao = 1899 },
            new Livro { Titulo = "O Senhor dos Anéis", Autor = "J.R.R. Tolkien", AnoPublicacao = 1954 },
            new Livro { Titulo = "Cem Anos de Solidão", Autor = "Gabriel García Márquez", AnoPublicacao = 2002 },
            new Livro { Titulo = "1984", Autor = "George Orwell", AnoPublicacao = 1949 },
            new Livro { Titulo = "O Pequeno Príncipe", Autor = "Antoine de Saint-Exupéry", AnoPublicacao = 2001 }
        };
        
    var ListBook = livros.Where(livros => livros.AnoPublicacao >= 2000)
        .ToList();

    foreach (var item in ListBook) item.MostrarDetalhes();
   
}

void LinqQuestion3()
{
    //Dada uma lista de produtos com nome e preço, criar uma consulta LINQ para calcular o preço médio dos produtos.
    List<Produto> produtos = new List<Produto>
        {
            new Produto { Nome = "Notebook", Preco = 3500.00m },
            new Produto { Nome = "Smartphone", Preco = 2200.50m },
            new Produto { Nome = "Fone de Ouvido", Preco = 199.99m },
            new Produto { Nome = "Monitor", Preco = 899.90m },
            new Produto { Nome = "Teclado Mecânico", Preco = 350.00m }
        };

    var PrecoMedio = produtos.Average(produtos => produtos.Preco);

    Console.WriteLine(PrecoMedio);

}

void LinqQuestion4()
{
    //Dada uma lista de inteiros, criar uma consulta LINQ para retornar apenas os números pares.
    List<int> listOfNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 7, 8, 8, 9, 10, 11, 12, 12, 13, 14, 15, 16, 16 };

    var listPares = listOfNumbers.Where(n => n % 2 == 0);

    foreach (var p in listPares) Console.WriteLine(p);

}

void number1e2ConsumindoAPIandLINQs()
{
    Console.WriteLine("Digite um nome, idade e e-mail:");
    string nome = "vitor";
    int idade = 20;
    string email = "Vitor@exemplo.com";

    Pessoa p1 = new Pessoa(nome, idade, email);

    var jsonp1 = JsonSerializer.Serialize(p1);

    string arquivo = $"Serialize-{p1.Nome}.json";

    File.WriteAllText(arquivo, jsonp1);

    Console.WriteLine($"Arquivo foi criado com sucesso! {Path.GetFullPath(arquivo)}" );

    // Desserializar json -- 
    string caminhoArquivo = Path.GetFullPath(arquivo);
    string Pessoa2 = File.ReadAllText(caminhoArquivo);

    var p2 = JsonSerializer.Deserialize<Pessoa>(Pessoa2);

    Console.WriteLine($"{p2.Nome},{p2.Idade},{p2.Email}.");

    

}

void number3e4ConsumindoAPIandLINQS()
{
    //Serializar Varias Pessoas --

    Console.WriteLine("digite quantas pessoas você quer cadastrar:");
    //criar lista de pessoas
    List<Pessoa> pessoasSerialize = new List<Pessoa>();
    pessoasSerialize.Add(new Pessoa("Sarah", 19, "sasdger"));
    pessoasSerialize.Add(new Pessoa("Sar", 19, "sger"));
    pessoasSerialize.Add(new Pessoa("S", 19, "sas"));

    // transforma a lista em json (ele aceita tanto um objeto quanto uma lista de objetos --
    var jsonPessoas = JsonSerializer.Serialize(pessoasSerialize);

    //nome do arquivo
    string ArquivoPessoas = "PessoasJson.json";

    //cria o arquivo passando o Json e o "Path" do arquivo --
    File.WriteAllText(ArquivoPessoas, jsonPessoas);

    Console.WriteLine($"Foi criado com sucesso! {Path.GetFullPath(ArquivoPessoas)}");


    // le Varias Pessoas

    string caminhoVariasPessoas = Path.GetFullPath(ArquivoPessoas);

    var fileWithJson = File.ReadAllText(caminhoVariasPessoas);

    var DeserializingFileJson = JsonSerializer.Deserialize<List<Pessoa>>(fileWithJson);

    foreach(var obj in DeserializingFileJson)
    {
        Console.WriteLine($"{obj.Nome},{obj.Email},{obj.Idade}");
    }

}

void number5CriandoArquivosCsharp()
{
    List<Pessoa> pessoasSerialize = new List<Pessoa>();
    pessoasSerialize.Add(new Pessoa("Sarah", 19, "sasdger"));
    pessoasSerialize.Add(new Pessoa("Sar", 19, "sger"));
    pessoasSerialize.Add(new Pessoa("S", 19, "sas"));

    string nome = "vitor";
    int idade = 20;
    string email = "Vitor@exemplo.com";
    Pessoa p1 = new Pessoa(nome, idade, email);

    pessoasSerialize.Add(p1);

    Console.WriteLine("Digite uma idade que deseja ver as pessoas que contenham ela:");
    int idadeSearch = int.Parse(Console.ReadLine());

    string caminho = $"ListaDePessoaCriada.json";

    string JsonSerializado = JsonSerializer.Serialize<List<Pessoa>>(pessoasSerialize);

    File.WriteAllText(caminho, JsonSerializado);

    var jsonString = File.ReadAllText(caminho);

    List<Pessoa> Pessoas = JsonSerializer.Deserialize<List<Pessoa>>(jsonString);

    var pessoasXidade = Pessoas.Where(x=>x.Idade == idadeSearch).ToList();

    foreach(var pessoa in pessoasXidade)
    {
        Console.WriteLine($"{pessoa.Nome}");
    }
}

number5CriandoArquivosCsharp();
