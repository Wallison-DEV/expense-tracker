<template>
  <div>
    <BalanceSummary :balance="balance" />
    <TransactionForm @submit="addTransaction" ref="transactionForm" />
    <TransactionList 
      :transactions="transactions"
      @edit="startEditTransaction"
      @delete="deleteTransaction"
    />
  </div>
</template>

<script>
export default {
  data() {
    return {
      transactions: [],
      balance: 0,
      editIndex: null,
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
      if (this.editIndex === null) {
        try {
          const response = await this.$axios.post('/api/Transactions', transaction, {
            headers: {
              'Content-Type': 'application/json'
            }
          });
          this.transactions.push(response.data);
        } catch (error) {
          console.error('Error adding transaction:', error);
        }
      } else {
        try {
          const response = await this.$axios.put(`/api/Transactions/${this.transactions[this.editIndex].id}`, {
            id: this.transactions[this.editIndex].id,
            description: transaction.description,
            amount: transaction.amount,
            type: transaction.type
          }, {
            headers: {
              'Content-Type': 'application/json'
            }
          });
          this.transactions.splice(this.editIndex, 1, response.data);
          this.updateBalance(); // Atualiza o saldo após a edição
          this.fetchTransactions(); // Atualiza a lista de transações após a edição
        } catch (error) {
          console.error('Error updating transaction:', error);
        }
        this.editIndex = null;
      }
    },
    startEditTransaction(index) {
      this.editIndex = index;
      this.$refs.transactionForm.setEditTransaction(this.transactions[index]);
    },
    async deleteTransaction(index) {
      try {
        await this.$axios.delete(`/api/Transactions/${this.transactions[index].id}`, {
          headers: {
            'Content-Type': 'application/json'
          }
        });
        this.transactions.splice(index, 1);
        this.updateBalance();
      } catch (error) {
        console.error('Error deleting transaction:', error);
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
