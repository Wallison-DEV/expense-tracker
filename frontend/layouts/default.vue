<template>
  <v-app>
    <v-app-bar app dark>
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
      <v-toolbar-title class="ml-8">Expense Tracker</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn text>Relatórios</v-btn>
      <v-btn text>Configurações</v-btn>
      <v-btn text>Logout</v-btn>
    </v-app-bar>

    <v-main>
      <v-container class="p-8">
        <Nuxt />
      </v-container>
    </v-main>

    <v-footer app dark>
      <span>&copy; {{ new Date().getFullYear() }} Expense Tracker</span>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  name: 'DefaultLayout',
  data() {
    return {
      drawer: true,
    };
  },
};
</script>

<style>
body {
  background-color: #f9f9f9;
}

.v-app-bar {
  background-color: #673ab7 !important;
}

.v-container {
  background-color: #ffffff;
  border-radius: 8px;
  box-shadow: 0px 4px 12px rgba(0, 0, 0, 0.1);
}

.v-footer {
  background-color: #673ab7 !important;
  color: #ffffff;
}
</style>
