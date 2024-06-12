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
        const response = await this.$axios.get('/api/Transactions');
        this.transactions = response.data;
        this.updateBalance();
      } catch (error) {
        console.error('Error fetching transactions:', error);
      }
    },
    async addTransaction(transaction) {
      try {
        const response = await this.$axios.post('/api/Transactions', {
          amount: transaction.amount,
          description: transaction.description,
          type: transaction.type
        }, {
          headers: {
            'Content-Type': 'application/json'
          }
        });
        this.transactions.push(response.data);
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
