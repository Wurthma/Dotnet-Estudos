# Handling Exceptions

Esse exemplo é baseado no conteúdo do Tim Corey: https://youtu.be/LSkbnpjCEkk

Documentação oficial: 
 - https://docs.microsoft.com/pt-br/dotnet/csharp/language-reference/keywords/throw
 - https://docs.microsoft.com/pt-br/dotnet/csharp/language-reference/keywords/try-catch
 - https://docs.microsoft.com/pt-br/dotnet/csharp/language-reference/keywords/try-finally
 - https://docs.microsoft.com/pt-br/dotnet/csharp/language-reference/keywords/try-catch-finally

## Resumo

Tratamento de exceção tem como objetivo, como o nome já entrega, o tratamento de erros da aplicação. Esse tratamento deve ser realizado de formas diferentes para cada caso e deve-se tomar certos cuidados ao lidar com essas exceções.

### Pontos importantes

- Os tratamentos de exceção devem ser feitos de preferência no nível mais alto da aplicação.
- O `StackTrace` original da exceção pode ser mantido usando o apenas `throw`.
- Ao usar o `throw ex` "jogando" a exceção capturada, o `StackTrace` original ficará no `InnerException`.
