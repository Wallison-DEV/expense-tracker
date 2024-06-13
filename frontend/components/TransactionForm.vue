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
                    <v-btn :loading="loading" style="color: #fff" color="#673ab7" class="text-white" rounded type="submit">
                        {{ editMode ? 'Atualizar' : 'Adicionar' }}
                    </v-btn>
                </div>
            </v-form>
        </v-col>
    </v-row>
</template>

<script>
export default {
    props: {
        editTransaction: {
            type: Object,
            default: null
        }
    },
    data() {
        return {
            description: '',
            amount: null,
            type: 0,
            editMode: false,
            loading: false
        }
    },
    methods: {
        submit() {
            this.$emit('submit', {
                description: this.description,
                amount: parseFloat(this.amount) || 0,
                type: this.type
            });
            this.resetForm();
        },
        setEditTransaction(transaction) {
            this.description = transaction.description;
            this.amount = transaction.amount;
            this.type = transaction.type;
            this.editMode = true;
        },
        resetForm() {
            this.description = '';
            this.amount = null;
            this.type = 0;
            this.editMode = false;
        }
    }
}
</script>
