<template>

  <div>
    <h1>Matt Jones: Mayvue Motion Pictures</h1>
    <Table />
  </div>
</template>

<script>
import Table from "./components/Table.vue";

export default {
  name: "App",
  components: {
    Table,
  },
};
</script>

<style lang="scss">
@import "~@/assets/scss/vendors/bootstrap-vue/index";

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}
body {
  display: block;
  background-color: rgb(31, 35, 37) !important;
  margin: auto !important;
  max-width: 800px;
  color: white;
  text-align: center;
  margin-top: 60px !important;
}
</style>
