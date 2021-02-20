# Theads, ThreadPool e Tasks

Qual a diferença entre Threads e Tasks?

### Theads:
Thread é um conceito de baixo nível (te da um controle maior sobre as threads, e isso na maiorida das vezes é dispensável): se você está iniciando um thread diretamente, sabe que será um thread separado, em vez de executar no pool de threads.

### ThreadPool

ThreadPool é um invólucro em torno de um pool de threads mantido pelo CLR. ThreadPool não lhe dá nenhum controle; você pode enviar trabalho para execução em algum ponto e pode controlar o tamanho do pool, mas não pode definir mais nada. Você não consegue nem dizer quando o pool começará a executar o trabalho que você enviar a ele.

### Tasks:

É uma abstração acima dos Threads. Ele usa o pool de threads (ThreadPool) (a menos que você especifique a tarefa como uma operação LongRunning; nesse caso, um novo thread é criado sob o capô para você).
Task é mais do que apenas uma abstração de "onde executar algum código" - é apenas "a promessa de um resultado no futuro".

### Características:

- Uma task pode ter multiplos processamentos acontecendo ao mesmo tempo. Threads podem ter uma única execução por vez.
- Tasks suportam cancelamento de execução usando o cancellation tokens. Com Thread não é possível fazer esse cancelamento.
- Uma Task é um conceito de nível mais alto do que Thread.