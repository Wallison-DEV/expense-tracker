<template>
    <v-card class="balance-card" outlined>
        <v-card-title class="balance-title">Saldo Atual</v-card-title>
        <v-card-text class="balance-amount">{{ balance }}</v-card-text>
    </v-card>
</template>

<script>
export default {
    props: {
        balance: {
            type: Number,
            required: true
        }
    }
}
</script>

<style scoped>
.balance-card {
    max-width: 300px;
    margin: 0 auto;
    text-align: center;
    background-color: #f5f5f5;
}

.balance-title {
    font-size: 18px;
}

.balance-amount {
    font-size: 24px;
    font-weight: bold;
    color: #007bff;
}
</style>
