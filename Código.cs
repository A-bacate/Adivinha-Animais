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
       /*     Console.WriteLine("Animais disponiveis para adivinhar:");
            foreach (Animal animal in listaDeAnimais.animais)
            {
                if (animal != null) 
                {
                    Console.WriteLine($"- {animal.Nome}");
                }
            }
            Console.WriteLine("----------------------------------");
          */  
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
        public Animal[] animais = new Animal[42]; 

        public void InicializarAnimais()
        {
            
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

            
            Animal aguia = new Animal();
            aguia.Nome = "Aguia";
            aguia.ID = 3;
            aguia.Habitat = "Aereo";
            aguia.Cores = new string[] { "marrom", "branco" }; 
            aguia.ExpectativaVida = 25;
            aguia.Dieta = new Dieta { Tipo = "Carnivoro" };
            aguia.Classe = new Classe { Casta = "Ave"};
            aguia.TamanhoNivel = 2; 
            animais[2] = aguia;

            
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

            
            Animal pinguim = new Animal();
            pinguim.Nome = "Pinguim";
            pinguim.ID = 11;
            pinguim.Habitat = "Aquatico"; 
            pinguim.Cores = new string[] { "preto", "branco" };
            pinguim.ExpectativaVida = 15;
            pinguim.Dieta = new Dieta { Tipo = "Carnivoro" };
            pinguim.Classe = new Classe { Casta = "Ave" };
            pinguim.TamanhoNivel = 1;
            animais[10] = pinguim;

            
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
            
            
            Animal borboleta = new Animal();
            borboleta.Nome = "Borboleta";
            borboleta.ID = 22;
            borboleta.Habitat = "Aereo";
            borboleta.Cores = new string[] { "cores variadas", "preto", "laranja", "amarelo" };
            borboleta.ExpectativaVida = 0.1; // Meses, convertido para anos
            borboleta.Dieta = new Dieta { Tipo = "Herbivoro" }; // Nectar
            borboleta.Classe = new Classe { Casta = "Inseto" };
            borboleta.TamanhoNivel = 1;
            animais[21] = borboleta;

            
            Animal anta = new Animal();
            anta.Nome = "Anta";
            anta.ID = 23;
            anta.Habitat = "Terrestre";
            anta.Cores = new string[] { "marrom" };
            anta.ExpectativaVida = 25;
            anta.Dieta = new Dieta { Tipo = "Herbivoro" };
            anta.Classe = new Classe { Casta = "Mamifero" };
            anta.TamanhoNivel = 3;
            animais[22] = anta;

            
            Animal sapo = new Animal();
            sapo.Nome = "Sapo";
            sapo.ID = 24;
            sapo.Habitat = "Terrestre"; // E aquatico
            sapo.Cores = new string[] { "verde", "marrom", "cinza" };
            sapo.ExpectativaVida = 10;
            sapo.Dieta = new Dieta { Tipo = "Carnivoro" }; // Insetos
            sapo.Classe = new Classe { Casta = "Anfibio" };
            sapo.TamanhoNivel = 1;
            animais[23] = sapo;

            
            Animal abelha = new Animal();
            abelha.Nome = "Abelha";
            abelha.ID = 25;
            abelha.Habitat = "Aereo";
            abelha.Cores = new string[] { "amarelo", "preto" };
            abelha.ExpectativaVida = 0.1; // Meses, convertido para anos
            abelha.Dieta = new Dieta { Tipo = "Herbivoro" }; // Nectar e polen
            abelha.Classe = new Classe { Casta = "Inseto" };
            abelha.TamanhoNivel = 1;
            animais[24] = abelha;

            
            Animal macaco = new Animal();
            macaco.Nome = "Macaco";
            macaco.ID = 26;
            macaco.Habitat = "Terrestre"; // E arboreo
            macaco.Cores = new string[] { "marrom", "preto", "cinza" };
            macaco.ExpectativaVida = 20;
            macaco.Dieta = new Dieta { Tipo = "Onivoro" };
            macaco.Classe = new Classe { Casta = "Mamifero" };
            macaco.TamanhoNivel = 2;
            animais[25] = macaco;

            
            Animal ra = new Animal();
            ra.Nome = "Ra";
            ra.ID = 27;
            ra.Habitat = "Aquatico"; // E terrestre
            ra.Cores = new string[] { "verde", "marrom" };
            ra.ExpectativaVida = 10;
            ra.Dieta = new Dieta { Tipo = "Carnivoro" }; // Insetos
            ra.Classe = new Classe { Casta = "Anfibio" };
            ra.TamanhoNivel = 1;
            animais[26] = ra;

            
            Animal formiga = new Animal();
            formiga.Nome = "Formiga";
            formiga.ID = 28;
            formiga.Habitat = "Terrestre";
            formiga.Cores = new string[] { "preto", "marrom", "vermelho" };
            formiga.ExpectativaVida = 0.5; // Anos para rainhas, meses para operarias
            formiga.Dieta = new Dieta { Tipo = "Onivoro" };
            formiga.Classe = new Classe { Casta = "Inseto" };
            formiga.TamanhoNivel = 1;
            animais[27] = formiga;

            
            Animal perereca = new Animal();
            perereca.Nome = "Perereca";
            perereca.ID = 29;
            perereca.Habitat = "Terrestre"; // E arborea
            perereca.Cores = new string[] { "verde", "marrom", "azul", "vermelho" };
            perereca.ExpectativaVida = 5;
            perereca.Dieta = new Dieta { Tipo = "Carnivoro" }; // Insetos
            perereca.Classe = new Classe { Casta = "Anfibio" };
            perereca.TamanhoNivel = 1;
            animais[28] = perereca;

            
            Animal besouro = new Animal();
            besouro.Nome = "Besouro";
            besouro.ID = 30;
            besouro.Habitat = "Terrestre";
            besouro.Cores = new string[] { "preto", "marrom", "verde", "metalico" };
            besouro.ExpectativaVida = 1; // Anos
            besouro.Dieta = new Dieta { Tipo = "Onivoro" }; // Varia
            besouro.Classe = new Classe { Casta = "Inseto" };
            besouro.TamanhoNivel = 1;
            animais[29] = besouro;

            
            Animal lagarta = new Animal();
            lagarta.Nome = "Lagarta";
            lagarta.ID = 31;
            lagarta.Habitat = "Terrestre";
            lagarta.Cores = new string[] { "verde", "marrom", "listrado", "pontilhado" };
            lagarta.ExpectativaVida = 0.05; 
            lagarta.Dieta = new Dieta { Tipo = "Herbivoro" };
            lagarta.Classe = new Classe { Casta = "Inseto" };
            lagarta.TamanhoNivel = 1;
            animais[30] = lagarta;

            
            Animal cabra = new Animal();
            cabra.Nome = "Cabra";
            cabra.ID = 32;
            cabra.Habitat = "Terrestre";
            cabra.Cores = new string[] { "branco", "preto", "marrom", "cinza" };
            cabra.ExpectativaVida = 15;
            cabra.Dieta = new Dieta { Tipo = "Herbivoro" };
            cabra.Classe = new Classe { Casta = "Mamifero" };
            cabra.TamanhoNivel = 2;
            animais[31] = cabra;

            
            Animal jacare = new Animal();
            jacare.Nome = "Jacare";
            jacare.ID = 33;
            jacare.Habitat = "Aquatico"; // E terrestre
            jacare.Cores = new string[] { "verde", "marrom", "cinza" };
            jacare.ExpectativaVida = 50;
            jacare.Dieta = new Dieta { Tipo = "Carnivoro" };
            jacare.Classe = new Classe { Casta = "Reptil" };
            jacare.TamanhoNivel = 4;
            animais[32] = jacare;

            
            Animal bichoPau = new Animal();
            bichoPau.Nome = "Bicho Pau";
            bichoPau.ID = 34;
            bichoPau.Habitat = "Terrestre";
            bichoPau.Cores = new string[] { "marrom", "verde" };
            bichoPau.ExpectativaVida = 1; // Anos
            bichoPau.Dieta = new Dieta { Tipo = "Herbivoro" };
            bichoPau.Classe = new Classe { Casta = "Inseto" };
            bichoPau.TamanhoNivel = 1;
            animais[33] = bichoPau;

            
            Animal camaleao = new Animal();
            camaleao.Nome = "Camaleao";
            camaleao.ID = 35;
            camaleao.Habitat = "Terrestre";
            camaleao.Cores = new string[] { "verde", "marrom", "amarelo", "azul", "muda de cor" }; 
            camaleao.ExpectativaVida = 5;
            camaleao.Dieta = new Dieta { Tipo = "Carnivoro" }; 
            camaleao.Classe = new Classe { Casta = "Reptil" };
            camaleao.TamanhoNivel = 1;
            animais[34] = camaleao;

            
            Animal louvaDeus = new Animal();
            louvaDeus.Nome = "Louva Deus";
            louvaDeus.ID = 36;
            louvaDeus.Habitat = "Terrestre";
            louvaDeus.Cores = new string[] { "verde", "marrom" };
            louvaDeus.ExpectativaVida = 0.5; 
            louvaDeus.Dieta = new Dieta { Tipo = "Carnivoro" }; 
            louvaDeus.Classe = new Classe { Casta = "Inseto" };
            louvaDeus.TamanhoNivel = 1;
            animais[35] = louvaDeus;

            
            Animal iguana = new Animal();
            iguana.Nome = "Iguana";
            iguana.ID = 37;
            iguana.Habitat = "Terrestre";
            iguana.Cores = new string[] { "verde", "marrom", "cinza" };
            iguana.ExpectativaVida = 15;
            iguana.Dieta = new Dieta { Tipo = "Herbivoro" };
            iguana.Classe = new Classe { Casta = "Reptil" };
            iguana.TamanhoNivel = 2;
            animais[36] = iguana; 

            
            Animal centopeia = new Animal();
            centopeia.Nome = "Centopeia";
            centopeia.ID = 38;
            centopeia.Habitat = "Terrestre";
            centopeia.Cores = new string[] { "marrom", "preto" };
            centopeia.ExpectativaVida = 5;
            centopeia.Dieta = new Dieta { Tipo = "Carnivoro" }; 
            centopeia.Classe = new Classe { Casta = "Miriapode" };
            centopeia.TamanhoNivel = 1;
            animais[37] = centopeia;

            
            Animal lagarto = new Animal();
            lagarto.Nome = "Lagarto";
            lagarto.ID = 39;
            lagarto.Habitat = "Terrestre";
            lagarto.Cores = new string[] { "verde", "marrom", "cinza", "padrao" };
            lagarto.ExpectativaVida = 10;
            lagarto.Dieta = new Dieta { Tipo = "Onivoro" };
            lagarto.Classe = new Classe { Casta = "Reptil" };
            lagarto.TamanhoNivel = 2;
            animais[38] = lagarto;

            
            Animal dragaoDeComodo = new Animal();
            dragaoDeComodo.Nome = "Dragao de Comodo";
            dragaoDeComodo.ID = 40;
            dragaoDeComodo.Habitat = "Terrestre";
            dragaoDeComodo.Cores = new string[] { "marrom", "cinza" };
            dragaoDeComodo.ExpectativaVida = 30;
            dragaoDeComodo.Dieta = new Dieta { Tipo = "Carnivoro" };
            dragaoDeComodo.Classe = new Classe { Casta = "Reptil" };
            dragaoDeComodo.TamanhoNivel = 4;
            animais[39] = dragaoDeComodo;

            
            Animal crocodilo = new Animal();
            crocodilo.Nome = "Crocodilo";
            crocodilo.ID = 41;
            crocodilo.Habitat = "Aquatico"; 
            crocodilo.Cores = new string[] { "verde", "marrom", "cinza" };
            crocodilo.ExpectativaVida = 70;
            crocodilo.Dieta = new Dieta { Tipo = "Carnivoro" };
            crocodilo.Classe = new Classe { Casta = "Reptil" };
            crocodilo.TamanhoNivel = 4;
            animais[40] = crocodilo;

            
            Animal tatu = new Animal();
            tatu.Nome = "Tatu";
            tatu.ID = 42;
            tatu.Habitat = "Terrestre";
            tatu.Cores = new string[] { "marrom", "cinza" };
            tatu.ExpectativaVida = 15;
            tatu.Dieta = new Dieta { Tipo = "Onivoro" };
            tatu.Classe = new Classe { Casta = "Mamifero" };
            tatu.TamanhoNivel = 2;
            animais[41] = tatu;
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
