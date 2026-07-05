using System;

namespace MyApplication
{
  // Interface
  interface IAnimal 
  {
    void animalSound(); // Sin body.
  }

  // Pig "implementa" la interfaz IAnimal
  class Pig : IAnimal 
  {
    
    public int Patas { get; set; } // PROPIEDAD

    public Pig(int patas) // CONSTRUCTOR
    {   
        this.Patas = patas;
    }

    // Implementación del método de la interfaz
    public void animalSound() 
    {
      Console.WriteLine("The pig says: wee wee");
    }
  }

  class Program 
  {
    static void Main(string[] args) 
    {
      Pig myPig = new Pig(4);  // Instanciamos un Pig de cuatro patas.
      myPig.animalSound();
      
      Console.Write("Patas del Chancho: ");
      Console.WriteLine(myPig.Patas); // Muestra el valor de la PROPIEDAD de la instancia.
    }
  }
}