using System;
using System.Linq;
using System.Collections.Generic;
using System.IO; 
/*
    Usar os métodos .Any() e .Contains()
    .Any() --> verifica se o array Cores do palpite não está vazio (se tem alguma cor lá dentro)
    
    .Contains() -->  verifica se a corPalpite existe dentro do array Cores do animalSorteado. O StringComparer.OrdinalIgnoreCase serve para que a comparação de texto ignore diferenças entre maiúsculas e minúsculas (por exemplo, "Marrom" seria igual a "marrom")
*/

class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        string resposta;
        bool continuar = true;

        Random rnd = new Random();
        ListaAnimais listaDeAnimais = new ListaAnimais();
        listaDeAnimais.InicializarAnimais("animais.txt"); 

        if (!listaDeAnimais.animais.Any())
        {
            Console.WriteLine("Nenhum animal foi carregado. Verifique o arquivo animais.txt.");
            
        }

        while (continuar) {
            
                //teste
            /*Console.WriteLine("Animais disponiveis para adivinhar:");
                foreach (Animal animal in listaDeAnimais.animais)
                {
                    if (animal != null) 
                    {
                        Console.WriteLine($"- {animal.Nome}");
                    }
                }
                Console.WriteLine("----------------------------------");
            */  
            int indiceSorteado = rnd.Next(0, listaDeAnimais.animais.Count);  
            Animal animalSorteado = listaDeAnimais.animais[indiceSorteado];

             Console.WriteLine($"O animal sorteado foi: {animalSorteado.Nome} (TESTE)");
            // NAO ESQUECER DE TIRAR ISSO PELO AMOR DE DEUS
            
            Console.WriteLine("Tente adivinhar o animal!");
            
            bool acertou = false;
            while (!acertou)
            {
                Console.WriteLine("\nEscreva o nome de um animal:");
                string palpiteNome = Console.ReadLine();
                
                Animal animalPalpite = listaDeAnimais.animais.FirstOrDefault(a => a.Nome.Equals(palpiteNome, StringComparison.OrdinalIgnoreCase));

                if (animalPalpite == null)
                {
                    Console.WriteLine("Esse animal nao esta na lista! Tente novamente.");
                }
                else
                {
                    if (animalSorteado.Nome.Equals(palpiteNome, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("\n*+Acertou!+*");
                        Console.WriteLine($"\nNome: {animalSorteado.Nome}");
                        Console.WriteLine($"Habitat: {animalSorteado.Habitat}");
                        Console.WriteLine("Cores:");
                        if (animalSorteado.Cores != null && animalSorteado.Cores.Any())
                        {
                            foreach (string cor in animalSorteado.Cores)
                            {
                                Console.WriteLine($"- {cor}");
                            }
                        }
                        else
                        {
                            // Só CASO eu tenha esquecido de adicionar cor
                            Console.WriteLine("- Nenhuma cor principal listada."); 
                        }
                        
                        Console.WriteLine($"Dieta: {animalSorteado.Dieta.Tipo}");
                        Console.WriteLine($"Classe: {animalSorteado.Classe.Casta}");
                        Console.WriteLine($"Expectativa de Vida (anos): {animalSorteado.ExpectativaVida}");
                        Console.WriteLine($"Tamanho (nivel): {animalSorteado.TamanhoNivel}"); 
                        
                        acertou = true;
                    }
                    else
                    {
                        Console.WriteLine("Errou!");
                        Console.WriteLine($"\nNome: {animalPalpite.Nome}");
                        Console.WriteLine($"Habitat: {animalPalpite.Habitat}");
                        Console.WriteLine("Cores:");
                        if (animalPalpite.Cores != null && animalPalpite.Cores.Any())

                        {
                            foreach (string cor in animalPalpite.Cores)
                            {
                                Console.WriteLine($"- {cor}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("- Nenhuma cor principal listada.");
                        }
                        
                        Console.WriteLine($"Dieta: {animalPalpite.Dieta.Tipo}");
                        Console.WriteLine($"Classe: {animalPalpite.Classe.Casta}");
                        Console.WriteLine($"Expectativa de Vida (anos): {animalPalpite.ExpectativaVida}");
                        Console.WriteLine($"Tamanho (nivel): {animalPalpite.TamanhoNivel}");

                        Console.WriteLine ("\n*+[Dicas]+*\n");
                        Comparacao(animalSorteado, animalPalpite);
                    }
                }
            }
            Console.WriteLine("\n\n*+Deseja jogar de novo?+*\n(sim/não)");
            resposta = Console.ReadLine();
            if (!resposta.Equals("sim", StringComparison.OrdinalIgnoreCase)) {
                continuar = false;
            }
            Console.Clear();
        }
    }

    public static void Comparacao(Animal sorteado, Animal palpite)
    {
        Console.WriteLine("--- Dicas ---");

        // Dica de Habitat
        if (sorteado.Habitat == palpite.Habitat)
        {
            Console.WriteLine($"Habitat: {palpite.Habitat} (OK)"); 
        }
        else
        {
            Console.WriteLine($"Habitat: {palpite.Habitat} (X)"); 
        }

        Console.Write("Cores: ");
        if (palpite.Cores != null && palpite.Cores.Any()) 
        {
            foreach (string corPalpite in palpite.Cores) 
            {
                if (sorteado.Cores != null && sorteado.Cores.Contains(corPalpite, StringComparer.OrdinalIgnoreCase))
                {
                    Console.Write($"[{corPalpite} (OK)] "); 
                }
                else
                {
                    Console.Write($"[{corPalpite} (X)] "); 
                }
            }
            Console.WriteLine(); 
        }
        else
        {
            Console.WriteLine("Nenhum dos animais tem cores principais listadas. (?)"); 
        }
        
        // Dica de Dieta
        if (sorteado.Dieta.Tipo == palpite.Dieta.Tipo)
        {
            Console.WriteLine($"Dieta: {palpite.Dieta.Tipo} (OK)");
        }
        else
        {
            Console.WriteLine($"Dieta: {palpite.Dieta.Tipo} (X)");
        }
        
        // Dica de Classe
        if (sorteado.Classe.Casta == palpite.Classe.Casta)
        {
            Console.WriteLine($"Classe: {palpite.Classe.Casta} (OK)");
        }
        else
        {
            Console.WriteLine($"Classe: {palpite.Classe.Casta} (X)");
        }

        // Dica de Expectativa de Vida (com seta)
        if (sorteado.ExpectativaVida == palpite.ExpectativaVida)
        {
            Console.WriteLine($"Expectativa de Vida: {palpite.ExpectativaVida} anos (OK)");
        }
        else if (palpite.ExpectativaVida < sorteado.ExpectativaVida)
        {
            Console.WriteLine($"Expectativa de Vida: {palpite.ExpectativaVida} anos (^ - mais)"); 
        }
        else
        {
            Console.WriteLine($"Expectativa de Vida: {palpite.ExpectativaVida} anos (v - menos)"); 
        }

        // Dica de Tamanho (com seta)
        if (sorteado.TamanhoNivel == palpite.TamanhoNivel)
        {
            Console.WriteLine($"Tamanho: {palpite.TamanhoNivel} (OK)");
        }
        else if (palpite.TamanhoNivel < sorteado.TamanhoNivel)
        {
            Console.WriteLine($"Tamanho: {palpite.TamanhoNivel} (^ - maior)"); 
        }
        else
        {
            Console.WriteLine($"Tamanho: {palpite.TamanhoNivel} (v - menor)"); 
        }
    }

    public class Dieta
    {
        public string Tipo { get; set; } 
    }

    public class Classe
    {
        public string Casta { get; set; } 
    }

    public class Animal
    {
        public string Nome { get; set; }
        public int ID { get; set; }
        public string Habitat { get; set; } 
        public string[] Cores { get; set; }
        public double ExpectativaVida { get; set; } 
        public Dieta Dieta { get; set; } 
        public Classe Classe { get; set; }
        public int TamanhoNivel { get; set; } 
    }

    public class ListaAnimais
    {
        public List<Animal> animais = new List<Animal>(); 
    
        public void InicializarAnimais(string caminhoArquivo = "animais.txt")
        {
            if (!File.Exists(caminhoArquivo))
            {
                Console.WriteLine($"Erro: Arquivo '{caminhoArquivo}' nao encontrado.");
                return; // Sai do método se o arquivo não existir
            }

            string[] linhas = File.ReadAllLines(caminhoArquivo);

            foreach (string linha in linhas)
            {
                // Pula linhas vazias
                if (string.IsNullOrWhiteSpace(linha))
                {
                    continue; 
                }

                string[] partes = linha.Split(','); // Divide a linha por vírgula

                // Verifica se tem o número esperado de partes (Nome, ID, Habitat, Cores, Vida, Dieta, Classe, Tamanho)
                if (partes.Length == 8) 
                {
                    Animal animal = new Animal();
                    animal.Nome = partes[0].Trim(); // .Trim() remove espaços extras
                    
                    // Tenta converter para int, se falhar, usa 0 (ou pode tratar erro)
                    if (int.TryParse(partes[1].Trim(), out int id))
                    {
                        animal.ID = id;
                    }
                    else
                    {
                        Console.WriteLine($"Aviso: ID invalido para o animal '{animal.Nome}'. Usando 0.");
                        animal.ID = 0; 
                    }

                    animal.Habitat = partes[2].Trim();
                    
                    // Cores: Separadas por ponto e vírgula
                    animal.Cores = partes[3].Trim().Split(';', StringSplitOptions.RemoveEmptyEntries); 
                    
                    // Expectativa de Vida: Pode ser double
                    if (double.TryParse(partes[4].Trim(), out double vida))
                    {
                        animal.ExpectativaVida = vida;
                    }
                    else
                    {
                        Console.WriteLine($"Aviso: Expectativa de vida invalida para o animal '{animal.Nome}'. Usando 0.");
                        animal.ExpectativaVida = 0;
                    }

                    animal.Dieta = new Dieta { Tipo = partes[5].Trim() };
                    animal.Classe = new Classe { Casta = partes[6].Trim() };
                    
                    // Tamanho: int
                    if (int.TryParse(partes[7].Trim(), out int tamanho))
                    {
                        animal.TamanhoNivel = tamanho;
                    }
                    else
                    {
                        Console.WriteLine($"Aviso: Nivel de tamanho invalido para o animal '{animal.Nome}'. Usando 0.");
                        animal.TamanhoNivel = 0;
                    }
                    
                    animais.Add(animal); // Adiciona o animal à lista
                }
                else
                {
                    Console.WriteLine($"Aviso: Linha com formato incorreto ignorada: {linha}");
                }
            }
        }
    }
}
