<template>
    <v-row class="my-5">
        <v-col v-for="(transaction, index) in transactions" :key="index" cols="12" sm="6" md="4" lg="3">
            <v-card class="mx-auto" max-width="344">
                <v-list-item>
                    <v-list-item-content>
                        <v-list-item-title>{{ transaction.description }}</v-list-item-title>
                        <v-list-item-subtitle
                            :class="{ 'text-success': transaction.type === 0, 'text-error': transaction.type === 1 }">
                            {{ displayAmount(transaction) }}
                        </v-list-item-subtitle>
                    </v-list-item-content>
                </v-list-item>
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
            if (transaction.type === 0) {
                return transaction.amount;
            } else {
                return '-' + Math.abs(transaction.amount);
            }
        }
    }
}
</script>
