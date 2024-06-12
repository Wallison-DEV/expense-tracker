export const state = () => ({
    transactions: [],
    balance: 0
})

export const mutations = {
    SET_TRANSACTIONS(state, transactions) {
        state.transactions = transactions
        state.balance = transactions.reduce((acc, transaction) => acc + transaction.amount, 0)
    },
    ADD_TRANSACTION(state, transaction) {
        state.transactions.push(transaction)
        state.balance += transaction.amount
    }
}

export const actions = {
    async fetchTransactions({ commit }) {
        try {
            const response = await this.$axios.get('/transactions')
            commit('SET_TRANSACTIONS', response.data)
        } catch (error) {
            console.error('Error fetching transactions:', error)
        }
    },
    async addTransaction({ commit }, transaction) {
        try {
            await this.$axios.post('/transactions', transaction)
            commit('ADD_TRANSACTION', transaction)
        } catch (error) {
            console.error('Error adding transaction:', error)
        }
    }
}

export const getters = {
    transactions: (state) => state.transactions,
    balance: (state) => state.balance
}
