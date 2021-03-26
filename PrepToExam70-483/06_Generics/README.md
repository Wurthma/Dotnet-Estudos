# Generics

Esse exemplo é baseado no conteúdo do Tim Corey: https://youtu.be/l6s7AvZx5j8

Documentação oficial: https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/generics/

## Resumo

Como `Generics` conseguis trabalhar com tipos no .Net que não são previamente definidos. Um bom exemplo de uso do `generics` pode ser observado no `List<T>` onde `T` é o tipo a ser recebido.

## Exemplo de método com generics

```csharp
public static List<T> LoadFromTextFile<T>(string filePath) where T : class, new()
{
	// ... conteúdo do método
}
```

Nesse exemplo criamos um método que deve retornar uma lista de um tipo indefinido. Mas nesse caso há um limitador (`where T : class, new()`) onde estamos definindo que o `T` deve ser uma `class` e que deve possuir um construtor sem parâmetros (`new()`).

Também é comum usar interfaces no `where`.

Para um exemplo completo e mais avançado baixar o projeto de exemplo.
