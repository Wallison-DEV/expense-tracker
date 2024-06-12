<template>
    <v-row justify="center">
        <v-col cols="12" sm="8" md="6">
            <v-form @submit.prevent="submit">
                <v-text-field v-model="description" label="Descrição"></v-text-field>
                <v-text-field v-model="amount" label="Valor" type="number"></v-text-field>
                <div class="d-flex justify-space-between align-center">
                    <v-radio-group v-model="type" row>
                        <v-radio :value="0" label="Entrada"></v-radio>
                        <v-radio :value="1" label="Saída"></v-radio>
                    </v-radio-group>
                    <v-btn color="#673ab7" style="color: #fff;" rounded="xl" type="submit">Adicionar</v-btn>
                </div>
            </v-form>
        </v-col>
    </v-row>
</template>

<script>
export default {
    data() {
        return {
            description: '',
            amount: null,
            type: 0
        }
    },
    methods: {
        submit() {
            this.$emit('submit', {
                description: this.description,
                amount: parseFloat(this.amount),
                type: this.type
            });
            this.description = '';
            this.amount = null;
            this.type = 0;
        }
    }
}
</script>
