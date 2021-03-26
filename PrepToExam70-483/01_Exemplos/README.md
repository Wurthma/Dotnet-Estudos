# Theads, ThreadPool e Tasks

Exemplos mais avançados no [projeto de exemplo referente ao vídeo do IAmTimCorey](../01_AdvancedAsyncSourceCode "projeto de exemplo referente ao vídeo do IAmTimCorey").


Ambas executam processos de forma paralela usando os nucles disponíveis no processador.

No projeto Exemplos01 há exemplos de execução básica usando `Theads`, `ThreadPool` e `Tasks` (opção 1) e podemos observar a diferença de execução de um processo sem paralelismo e com paralelismo.

> Neste exemplo você irá observar que com paralelismo temos uma execução mais rápida, mas tenha em mente que cenários mais complexos podem não ter o mesmo resultado.

Dê sempre preferência para o uso de Task, pois é um nível de abstração mais alto e o sistema controla a maior parte das decisões de controle.

## Qual a diferença entre Threads e Tasks?

### Theads:
Thread é um conceito de baixo nível (te da um controle maior sobre as threads, e isso na maiorida das vezes é dispensável): se você está iniciando um thread diretamente, sabe que será um thread separado, em vez de executar no pool de threads.

#### Task.ContinueWith

`Task.ContinueWith` é usado para definir uma ordem de passos que são dependentes e que só serão completados após a execução do passo anterior.
Exemplo:


### ThreadPool

ThreadPool é um invólucro em torno de um pool de threads mantido pelo CLR. ThreadPool não lhe dá nenhum controle; você pode enviar trabalho para execução em algum ponto e pode controlar o tamanho do pool, mas não pode definir mais nada. Você não consegue nem dizer quando o pool começará a executar o trabalho que você enviar a ele.

### Tasks:

É uma abstração acima dos Threads. Ele usa o pool de threads (ThreadPool) (a menos que você especifique a tarefa como uma operação LongRunning; nesse caso, um novo thread é criado sob o capô para você).
Task é mais do que apenas uma abstração de "onde executar algum código" - é apenas "a promessa de um resultado no futuro".

#### Async/Await

Async faz com que determinado método funcione de forma assíncrona, ou seja, ele rodará em background e durante esse processo outras tarefas podem ser realizadas, diferente de métodos síncronos que precisam necessariamente ser finalizados antes de outras tarefas serem iniciadas.

No exemplo da opção 4 é possível verificar um exemplo do uso do async/await.

> Notar que aplicações do tipo console precisam fazer o uso do `Wait` então não é possível no console continuar usando o mesmo enquanto a tarefa está em execução, consultar exemplos de aplicações web para verificar o comportamento de retorno do async/await.

## Parallel

Parallel é usado para realizar a execução paralela de tipo de derivados de `IEnumerable`. No código há um exemplo de uso do `Parallel.ForEach` (Exemplo da opção 5), no entanto é possível também usar o `Parallel.For`. 

Estudar também `AsParallel(IEnumerable)` do `System.Linq`.
Exemplo de uso:

```csharp
var listResults = GenerateResults();
var result = listResults.AsParallel().Where(x.ToString() == "Texto");
```

### O Exemplo Parallel:
No exemplo citado da opção 5 a mesma simulação de execução é realizada, sendo uma delas usando o método `ProcessResults` e a outro a método paralelo `ProcessResultsParallel`. Podemos observar que o método paralelo, executa muito mais rápido e faz uso de diversas Threads durante sua execução para possibilitar o paralelismo.

No exemplo deixamos o controle de quantidade de Threads com o sistema (não definido manualmente), mas podemos fazer o controle utilizando o `ParallelOptions`.

O método alterado, para controlar a quantidade de Threads, ficaria assim:

```csharp
public void ProcessResultsParallel()
{
    var listResults = GenerateResults();

    ParallelOptions op = new ParallelOptions();
    op.MaxDegreeOfParallelism = 10;

    Parallel.ForEach(listResults, op, item => {
        ProcessResult(item);
    });
}
```

O `CancellationToken` também pode ser controlado pelo `ParallelOptions` para realizar o cancelamento do processo.

### Características:

- Uma task pode ter múltiplos processamentos acontecendo ao mesmo tempo. Threads podem ter uma única execução por vez.
- Tasks suportam cancelamento de execução usando o cancellation tokens. Com Thread não é possível fazer esse cancelamento.
- Uma Task é um conceito de nível mais alto do que Thread.

### Fontes:

- https://youtu.be/2moh18sh5p4
- https://youtu.be/ZTKGRJy5P2M
- https://youtu.be/e-5o3ZBWg9Q

Exemplos mais avançados no [projeto de exemplo referente ao vídeo do IAmTimCorey](../01_AdvancedAsyncSourceCode "projeto de exemplo referente ao vídeo do IAmTimCorey").
