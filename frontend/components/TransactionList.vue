<template>
    <v-row class="my-5">
        <v-col v-for="(transaction, index) in transactions" :key="index" cols="12" sm="6" md="4" lg="3">
            <v-card class="mx-auto" max-width="344">
                <v-card-title class="d-flex justify-space-between align-center">
                    <span>{{ transaction.description }}</span>
                    <div>
                        <v-btn icon @click="editTransaction(index)">
                            <v-icon>mdi-pencil</v-icon>
                        </v-btn>
                        <v-btn icon @click="deleteTransaction(index)">
                            <v-icon>mdi-delete</v-icon>
                        </v-btn>
                    </div>
                </v-card-title>
                <v-card-text class="d-flex flex-column">
                    <div class="d-flex justify-space-between">
                        <span>Montante:</span>
                        <span :class="{ 'text-success': transaction.type === 0, 'text-error': transaction.type === 1 }">
                            {{ displayAmount(transaction) }}
                        </span>
                    </div>
                    <div class="d-flex justify-space-between">
                        <span>Tipo:</span>
                        <span>{{ transaction.type === 0 ? 'Entrada' : 'Saída' }}</span>
                    </div>
                </v-card-text>
            </v-card>
        </v-col>
    </v-row>
</template>

<script>
export default {
    props: {
        transactions: {
            type: Array,
            required: true
        }
    },
    methods: {
        displayAmount(transaction) {
            const amount = transaction.amount !== undefined ? transaction.amount : 0;
            const formattedAmount = amount.toLocaleString('en-US', { style: 'currency', currency: 'USD' });
            return transaction.type === 0 ? formattedAmount : `-${formattedAmount}`;
        },
        editTransaction(index) {
            this.$emit('edit', index);
        },
        deleteTransaction(index) {
            this.$emit('delete', index);
        }
    }
}
</script>

<style scoped>
.v-card-title {
    font-weight: bold;
}

.text-success {
    color: green;
}

.text-error {
    color: red;
}

.v-card-text {
    padding-top: 0;
}
</style>
