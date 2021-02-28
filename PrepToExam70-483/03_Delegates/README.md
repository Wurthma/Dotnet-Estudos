# Delegates

Documentação oficial: https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/delegates/using-delegates

Tim Corey: https://youtu.be/R8Blt5c-Vi4

Resumo:

`Delegate` encapsula um método que pode ser posteriormente enviando como se fosse uma propriedade para o método que recebe a delegação. Ou seja, você está delegando a chamada de um método para outro método.

## Exemplo simples:

```csharp
public class CartModel
{
    public delegate void MentionDiscount(decimal subTotal); // definição de um delegate
    
    public List<ProductModel> Items { get; set; } = new List<ProductModel>();

    public decimal GenerateTotal(MentionDiscount mentionDiscount) // recebe o delegate
    {
        decimal subTotal = Items.Sum(x => x.Price);
        
        mentionDiscount(subTotal); // O método atribuído ao delegate será chamado aqui...

        if (subTotal > 40)
        {
            subTotal *= 0.90M;
        }

        return subTotal;
    }
}
```

No código acima definimos um delegate e posteriormente no método `GenerateTotal` o mesmo foi atribuído como se fosse uma propriedade, mas no lugar dele devemos enviar um método que será chamado no trecho `mentionDiscount(subTotal);`.
Esse método deve retornar `void` e receber um `decimal`, conforme o contrato da definição do delegate.

Abaixo um exemplo de implementação de método que pode ser atribuído a esse delegate:

```csharp
private static void SubTotalAlert(decimal subTotal)
{
    Console.WriteLine($"O subtotal é: {subTotal}");
}
```

Abaixo exemplo da chamada para o método `GenerateTotal` da classe `CartModel`:

```csharp
cart.GenerateTotal(SubTotalAlert);
```
