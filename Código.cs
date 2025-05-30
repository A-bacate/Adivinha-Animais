using System;
using System.Linq; 
/*
    Usar os métodos .Any() e .Contains()
    .Any() --> verifica se o array Cores do palpite não está vazio (se tem alguma cor lá dentro)
    
    .Contains() -->  verifica se a corPalpite existe dentro do array Cores do animalSorteado. O StringComparer.OrdinalIgnoreCase serve para que a comparação de texto ignore diferenças entre maiúsculas e minúsculas (por exemplo, "Marrom" seria igual a "marrom")
*/

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        
        ListaAnimais listaDeAnimais = new ListaAnimais();
        listaDeAnimais.InicializarAnimais(); 
            //teste
            Console.WriteLine("Animais disponiveis para adivinhar:");
            foreach (Animal animal in listaDeAnimais.animais)
            {
                if (animal != null) 
                {
                    Console.WriteLine($"- {animal.Nome}");
                }
            }
            Console.WriteLine("----------------------------------");
            
        int indiceSorteado = rnd.Next(0, listaDeAnimais.animais.Length); 
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
        public Animal[] animais = new Animal[21]; 

        public void InicializarAnimais()
        {
            // Animal 1: Leao
            Animal leao = new Animal();
            leao.Nome = "Leao";
            leao.ID = 1;
            leao.Habitat = "Terrestre";
            leao.Cores = new string[] { "amarelo", "marrom" }; 
            leao.ExpectativaVida = 15;
            leao.Dieta = new Dieta { Tipo = "Carnivoro" };
            leao.Classe = new Classe { Casta = "Mamifero"}; 
            leao.TamanhoNivel = 3; 
            animais[0] = leao;

            // Animal 2: Golfinho
            Animal golfinho = new Animal();
            golfinho.Nome = "Golfinho";
            golfinho.ID = 2;
            golfinho.Habitat = "Aquatico";
            golfinho.Cores = new string[] { "cinza", "branco" }; 
            golfinho.ExpectativaVida = 30;
            golfinho.Dieta = new Dieta { Tipo = "Carnivoro" };
            golfinho.Classe = new Classe { Casta = "Mamifero"};
            golfinho.TamanhoNivel = 2; 
            animais[1] = golfinho;

            // Animal 3: Aguia
            Animal aguia = new Animal();
            aguia.Nome = "Aguia";
            aguia.ID = 3;
            aguia.Habitat = "Aereo";
            aguia.Cores = new string[] { "marrom", "branco" }; 
            aguia.ExpectativaVida = 25;
            aguia.Dieta = new Dieta { Tipo = "Carnivoro" };
            aguia.Classe = new Classe { Casta = "Ave"}; // Alterei para "Ave" singular
            aguia.TamanhoNivel = 2; 
            animais[2] = aguia;

            // Animal 4: Coelho
            Animal coelho = new Animal();
            coelho.Nome = "Coelho";
            coelho.ID = 4;
            coelho.Habitat = "Terrestre";
            coelho.Cores = new string[] { "marrom", "branco", "cinza" };
            coelho.ExpectativaVida = 8;
            coelho.Dieta = new Dieta { Tipo = "Herbivoro" };
            coelho.Classe = new Classe { Casta = "Mamifero"};
            coelho.TamanhoNivel = 1; 
            animais[3] = coelho;

            // Animal 5: Urso
            Animal urso = new Animal(); // Nome ajustado para "Urso"
            urso.Nome = "Urso";
            urso.ID = 5;
            urso.Habitat = "Terrestre";
            urso.Cores = new string[] { "marrom" };
            urso.ExpectativaVida = 20;
            urso.Dieta = new Dieta { Tipo = "Onivoro" };
            urso.Classe = new Classe { Casta = "Mamifero"};
            urso.TamanhoNivel = 4; 
            animais[4] = urso;

            // Novos animais (seguindo sua lista e adicionando propriedades)
            // Animal 6: Gato
            Animal gato = new Animal();
            gato.Nome = "Gato";
            gato.ID = 6;
            gato.Habitat = "Terrestre";
            gato.Cores = new string[] { "preto", "branco", "laranja", "cinza", "marrom" }; // Varias cores possiveis
            gato.ExpectativaVida = 15;
            gato.Dieta = new Dieta { Tipo = "Carnivoro" };
            gato.Classe = new Classe { Casta = "Mamifero" };
            gato.TamanhoNivel = 1;
            animais[5] = gato;

            // Animal 7: Cachorro
            Animal cachorro = new Animal();
            cachorro.Nome = "Cachorro";
            cachorro.ID = 7;
            cachorro.Habitat = "Terrestre";
            cachorro.Cores = new string[] { "preto", "branco", "marrom", "caramelo", "cinza" }; // Varias cores possiveis
            cachorro.ExpectativaVida = 13;
            cachorro.Dieta = new Dieta { Tipo = "Onivoro" };
            cachorro.Classe = new Classe { Casta = "Mamifero" };
            cachorro.TamanhoNivel = 2; // Pode variar de pequeno a grande, entao medio eh um bom padrao
            animais[6] = cachorro;

            // Animal 8: Porco
            Animal porco = new Animal();
            porco.Nome = "Porco";
            porco.ID = 8;
            porco.Habitat = "Terrestre";
            porco.Cores = new string[] { "rosa", "marrom", "preto" };
            porco.ExpectativaVida = 10;
            porco.Dieta = new Dieta { Tipo = "Onivoro" };
            porco.Classe = new Classe { Casta = "Mamifero" };
            porco.TamanhoNivel = 2;
            animais[7] = porco;

            // Animal 9: Galinha
            Animal galinha = new Animal();
            galinha.Nome = "Galinha";
            galinha.ID = 9;
            galinha.Habitat = "Terrestre";
            galinha.Cores = new string[] { "branco", "marrom", "preto", "vermelho" };
            galinha.ExpectativaVida = 5;
            galinha.Dieta = new Dieta { Tipo = "Onivoro" };
            galinha.Classe = new Classe { Casta = "Ave" };
            galinha.TamanhoNivel = 1;
            animais[8] = galinha;

            // Animal 10: Baleia
            Animal baleia = new Animal();
            baleia.Nome = "Baleia";
            baleia.ID = 10;
            baleia.Habitat = "Aquatico";
            baleia.Cores = new string[] { "cinza", "azul", "preto" };
            baleia.ExpectativaVida = 80;
            baleia.Dieta = new Dieta { Tipo = "Carnivoro" }; // Algumas sao carnivoras (krill, peixes)
            baleia.Classe = new Classe { Casta = "Mamifero" };
            baleia.TamanhoNivel = 4; // Gigante
            animais[9] = baleia;

            // Animal 11: Pinguim
            Animal pinguim = new Animal();
            pinguim.Nome = "Pinguim";
            pinguim.ID = 11;
            pinguim.Habitat = "Aquatico"; // Passa muito tempo na agua, mas vive em terra tambem
            pinguim.Cores = new string[] { "preto", "branco" };
            pinguim.ExpectativaVida = 15;
            pinguim.Dieta = new Dieta { Tipo = "Carnivoro" };
            pinguim.Classe = new Classe { Casta = "Ave" };
            pinguim.TamanhoNivel = 1;
            animais[10] = pinguim;

            // Animal 12: Cobra
            Animal cobra = new Animal();
            cobra.Nome = "Cobra";
            cobra.ID = 12;
            cobra.Habitat = "Terrestre";
            cobra.Cores = new string[] { "verde", "marrom", "preto", "amarelo" };
            cobra.ExpectativaVida = 10;
            cobra.Dieta = new Dieta { Tipo = "Carnivoro" };
            cobra.Classe = new Classe { Casta = "Reptil" };
            cobra.TamanhoNivel = 2; // Pode variar
            animais[11] = cobra;

            // Animal 13: Vaca
            Animal vaca = new Animal();
            vaca.Nome = "Vaca";
            vaca.ID = 13;
            vaca.Habitat = "Terrestre";
            vaca.Cores = new string[] { "branco", "preto", "marrom" };
            vaca.ExpectativaVida = 20;
            vaca.Dieta = new Dieta { Tipo = "Herbivoro" };
            vaca.Classe = new Classe { Casta = "Mamifero" };
            vaca.TamanhoNivel = 3;
            animais[12] = vaca;

            // Animal 14: Tartaruga
            Animal tartaruga = new Animal();
            tartaruga.Nome = "Tartaruga";
            tartaruga.ID = 14;
            tartaruga.Habitat = "Terrestre"; // Ou "Aquatico", dependendo da especie
            tartaruga.Cores = new string[] { "verde", "marrom", "preto" };
            tartaruga.ExpectativaVida = 50; // Muitas vivem muito
            tartaruga.Dieta = new Dieta { Tipo = "Onivoro" };
            tartaruga.Classe = new Classe { Casta = "Reptil" };
            tartaruga.TamanhoNivel = 1; // Pode ser 1 ou 2 dependendo da especie
            animais[13] = tartaruga;

            // Animal 15: Ovelha
            Animal ovelha = new Animal();
            ovelha.Nome = "Ovelha";
            ovelha.ID = 15;
            ovelha.Habitat = "Terrestre";
            ovelha.Cores = new string[] { "branco", "preto", "marrom" };
            ovelha.ExpectativaVida = 12;
            ovelha.Dieta = new Dieta { Tipo = "Herbivoro" };
            ovelha.Classe = new Classe { Casta = "Mamifero" };
            ovelha.TamanhoNivel = 2;
            animais[14] = ovelha;

            // Animal 16: Cavalo
            Animal cavalo = new Animal();
            cavalo.Nome = "Cavalo";
            cavalo.ID = 16;
            cavalo.Habitat = "Terrestre";
            cavalo.Cores = new string[] { "marrom", "preto", "branco", "ruivo", "cinza" };
            cavalo.ExpectativaVida = 30;
            cavalo.Dieta = new Dieta { Tipo = "Herbivoro" };
            cavalo.Classe = new Classe { Casta = "Mamifero" };
            cavalo.TamanhoNivel = 3;
            animais[15] = cavalo;
            
            // Animal 17: Raposa
            Animal raposa = new Animal();
            raposa.Nome = "Raposa";
            raposa.ID = 17;
            raposa.Habitat = "Terrestre";
            raposa.Cores = new string[] { "laranja", "vermelho", "branco", "preto" };
            raposa.ExpectativaVida = 5;
            raposa.Dieta = new Dieta { Tipo = "Onivoro" };
            raposa.Classe = new Classe { Casta = "Mamifero" };
            raposa.TamanhoNivel = 1;
            animais[16] = raposa;
    
            // Animal 18: Pombo
            Animal pombo = new Animal();
            pombo.Nome = "Pombo";
            pombo.ID = 18;
            pombo.Habitat = "Aereo";
            pombo.Cores = new string[] { "cinza", "branco", "preto" };
            pombo.ExpectativaVida = 5;
            pombo.Dieta = new Dieta { Tipo = "Herbivoro" }; // Principalmente sementes
            pombo.Classe = new Classe { Casta = "Ave" };
            pombo.TamanhoNivel = 1;
            animais[17] = pombo;
    
            // Animal 19: Tubarao
            Animal tubarao = new Animal();
            tubarao.Nome = "Tubarao";
            tubarao.ID = 19;
            tubarao.Habitat = "Aquatico";
            tubarao.Cores = new string[] { "cinza", "branco" };
            tubarao.ExpectativaVida = 30;
            tubarao.Dieta = new Dieta { Tipo = "Carnivoro" };
            tubarao.Classe = new Classe { Casta = "Peixe" }; // Tubaroes sao peixes cartilaginosos
            tubarao.TamanhoNivel = 4;
            animais[18] = tubarao;
    
            // Animal 20: Morcego
            Animal morcego = new Animal();
            morcego.Nome = "Morcego";
            morcego.ID = 20;
            morcego.Habitat = "Aereo"; // E Terrestre (cavernas, arvores)
            morcego.Cores = new string[] { "preto", "marrom", "cinza" };
            morcego.ExpectativaVida = 20;
            morcego.Dieta = new Dieta { Tipo = "Onivoro" }; // Frutas, insetos, nectar, sangue (alguns)
            morcego.Classe = new Classe { Casta = "Mamifero" };
            morcego.TamanhoNivel = 1;
            animais[19] = morcego;
    
            // Animal 21: Rato
            Animal rato = new Animal();
            rato.Nome = "Rato";
            rato.ID = 21;
            rato.Habitat = "Terrestre";
            rato.Cores = new string[] { "cinza", "marrom", "branco", "preto" };
            rato.ExpectativaVida = 3;
            rato.Dieta = new Dieta { Tipo = "Onivoro" };
            rato.Classe = new Classe { Casta = "Mamifero" };
            rato.TamanhoNivel = 1;
            animais[20] = rato;
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
            Console.WriteLine($"Expectativa de Vida: {palpite.ExpectativaVida} anos (^ - mais)"); // O animal sorteado vive MAIS
        }
        else
        {
            Console.WriteLine($"Expectativa de Vida: {palpite.ExpectativaVida} anos (v - menos)"); // O animal sorteado vive MENOS
        }

        // Dica de Tamanho (com seta)
        if (sorteado.TamanhoNivel == palpite.TamanhoNivel)
        {
            Console.WriteLine($"Tamanho: {palpite.TamanhoNivel} (OK)");
        }
        else if (palpite.TamanhoNivel < sorteado.TamanhoNivel)
        {
            Console.WriteLine($"Tamanho: {palpite.TamanhoNivel} (^ - maior)"); // O animal sorteado eh MAIOR
        }
        else
        {
            Console.WriteLine($"Tamanho: {palpite.TamanhoNivel} (v - menor)"); // O animal sorteado eh MENOR
        }
    }
}
