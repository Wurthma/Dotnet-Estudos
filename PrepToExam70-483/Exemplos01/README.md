# Theads, ThreadPool e Tasks

Ambas executam processos de forma paralela usando os nucles disponíveis no processador.

No projeto Exemplos01 há exemplos de execução básica usando `Theads`, `ThreadPool` e `Tasks` (opção 1) e podemos observar a diferença de exeução de um processo sem paralelismo e com paralelismo.

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

### Características:

- Uma task pode ter multiplos processamentos acontecendo ao mesmo tempo. Threads podem ter uma única execução por vez.
- Tasks suportam cancelamento de execução usando o cancellation tokens. Com Thread não é possível fazer esse cancelamento.
- Uma Task é um conceito de nível mais alto do que Thread.