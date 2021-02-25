# Interfaces: IDisposable, ICloneable, IEquatable, IComparer

## IDisposable

- Documentação oficial: https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose

`IDisposable` fornece um mecanismo para liberar recursos não gerenciados.

O uso principal dessa interface é para liberar recursos não-gerenciados. O coletor de lixo automaticamente libera a memória alocada para um objeto gerenciado quando esse objeto não é mais usado. No entanto, não é possível prever quando ocorrerá a coleta de lixo. Além disso, o coletor de lixo não tem conhecimento de recursos não gerenciados, como identificadores de janela, ou abrir arquivos e fluxos.

Exemplo prático do `IDisposable` no código fonte do arquivo [GerenciaArquivos.cs](./GerenciaArquivos.cs "GerenciaArquivos.cs").

## ICloneable

`ICloneable` dá suporte à clonagem, que cria uma nova instância de uma classe com o mesmo valor de uma instância existente.

Esta interface contém o método Clone que dá suporte à clonagem além do que é fornecido pelo método  Object.MemberwiseClone que cria uma cópia superficial de Object atual.

**O conceito de clonagem de objetos pode ter duas implementações:**

- **Shallow (superficial):** Clona o objeto mas copia apenas as referências para os objetos que referencia, exceção feita para os tipos por valor (value types) cujos valores são, por definição, sempre copiados.
- **Deep (profunda):** Clona o objeto e todos os objetos por ele referenciados.

Uma implementação do método Clone pode executar uma cópia profunda ou uma cópia superficial.

Em uma cópia profunda, todos os objetos são duplicados;
Em uma cópia superficial, apenas os objetos de nível superior são duplicados e os níveis inferiores contêm referências.

Exemplo prático do `ICloneable` no código fonte do arquivo [CloneableExample.cs](./CloneableExample.cs "CloneableExample.cs").

Fontes: 
- http://www.macoratti.net/19/05/c_iclone1.htm
- http://www.macoratti.net/18/01/c_uinterf2.htm