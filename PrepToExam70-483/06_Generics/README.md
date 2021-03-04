# Generics

Esse exemplo � baseado no conte�do do Tim Corey: https://youtu.be/l6s7AvZx5j8

Documenta��o oficial: https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/generics/

## Resumo

Como `Generics` conseguis trabalhar com tipos no .Net que n�o s�o previamente definidos. Um bom exemplo de uso do `generics` pode ser observado no `List<T>` onde `T` � o tipo a ser recebido.

## Exemplo de m�todo com generics

```csharp
public static List<T> LoadFromTextFile<T>(string filePath) where T : class, new()
{
	// ... conte�do do m�todo
}
```

Nesse exemplo criamos um m�todo que deve retornar uma lista de um tipo indefinido. Mas nesse caso h� um limitador (`where T : class, new()`) onde estamos definindo que o `T` deve ser uma `class` e que deve posssuir um construtor sem par�metros (`new()`).

Tamb�m � comum usar interfaces no `where`.

Para um exemplo completo e mais avan�ado baixar o projeto de exemplo.