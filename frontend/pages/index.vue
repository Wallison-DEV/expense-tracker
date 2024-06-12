<template>
  <div>
    <BalanceSummary :balance="balance" />
    <TransactionForm @submit="addTransaction" />
    <TransactionList :transactions="transactions" />
  </div>
</template>

<script>
export default {
  data() {
    return {
      transactions: [],
      balance: 0
    }
  },
  methods: {
    async fetchTransactions() {
      try {
        const response = await fetch('http://localhost:5142/api/Transactions', {
          method: 'GET',
          headers: {
            'Content-Type': 'application/json'
          }
        });
        if (!response.ok) {
          throw new Error('Failed to fetch transactions');
        }
        const data = await response.json();
        this.transactions = data;
        this.updateBalance();
      } catch (error) {
        console.error('Error fetching transactions:', error);
      }
    },
    async addTransaction(transaction) {
      try {
        const response = await fetch('http://localhost:5142/api/Transactions', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify({
            "amount": transaction.amount,
            "description": transaction.description,
            "type": transaction.type
          })
        });
        if (!response.ok) {
          throw new Error('Failed to add transaction');
        }
        const newTransaction = await response.json();
        this.transactions.push(newTransaction);
        this.updateBalance();
      } catch (error) {
        console.error('Error adding transaction:', error);
      }
    },
    updateBalance() {
      this.balance = this.transactions.reduce((acc, transaction) => {
        return acc + (transaction.type === 0 ? transaction.amount : -transaction.amount);
      }, 0);
    }
  },
  created() {
    this.fetchTransactions();
  }
}
</script>
