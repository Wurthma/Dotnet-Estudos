# Events

Documentação oficial: https://docs.microsoft.com/pt-br/dotnet/standard/events/

Este exemplo foi retirado do conteúdo do Tim Corey: https://youtu.be/-1cftB9q1kQ

Eventos são muito utilizados em UIs desktops (WinForms, WPF, UWP, etc)

## Exemplo

**Criação de evento:**

```csharp
public event EventHandler<string> TransactionApprovedEvent;
```

**Invocando evento:**

```csharp
TransactionApprovedEvent?.Invoke(this, paymentName);
```

O código acima para invocar o evento pode ser utilizado em qualquer trecho do código para fazer o "gatilho" do evento.

**Listener do evento**

```csharp
private void SavingsAccount_TransactionApprovedEvent(object sender, string e)
{
	savingsTransactions.DataSource = null;
	savingsTransactions.DataSource = customer.SavingsAccount.Transactions;
	savingsBalanceValue.Text = string.Format("{0:C2}", customer.SavingsAccount.Balance);
}
```

O "listener" define o comportamento do evento. Quando um evento tiver seu gatilho, o comportamento definido será executado.

## EventArgs

Para um exemplo de classe que faz herença do `EventArgs`, acessar o arquivo [OverdraftEventArgs.cs](/PrepToExam70-483/04_Events/DemoLibrary/OverdraftEventArgs.cs "OverdraftEventArgs.cs").