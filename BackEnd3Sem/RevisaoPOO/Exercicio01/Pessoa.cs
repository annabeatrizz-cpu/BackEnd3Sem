namespace RevisaoPOO
{
    public class Pessoa
    {
       public string Nome;

       private int Idade;

       public int idade()
         {
            if (idade > 0)
            {
                Console.WriteLine($"Text");
                
            }
         }


       public void ExibirDados()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Idade:{Idade}");
            
        }
        
    }
}