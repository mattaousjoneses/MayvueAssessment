<template>
  <div>
    <b-modal
      id="delete-modal"
      header-bg-variant="info"
      body-text-variant="dark"
      class="delete"
      size="lg"
      title="Delete Motion Picture"
      no-stacking
      v-model="modalShow"
      @hidden="resetModal"
      @ok="handleOK"
    >
      <b-container>
        <p>Are you sure you want to delete {{ textT }}?</p>
      </b-container>
    </b-modal>
  </div>
</template>

<script>
export default {
  name: "DeleteModule",
  props: {
    showModal: {
      type: Boolean,
      default: false,
    },
  },
  watch: {
    // showModal : showAddModal(){
    // }
  },

  methods: {
    showThatDeleteModal(id, textT, textD, textRY) {
      console.log("delete called");
      this.modalShow = true;
      this.id = id;
      this.textT = textT;
      this.textD = textD;
      this.textRY = textRY;
    },

    resetModal() {
      this.textT = "";
      this.textD = "";
      this.textRY = "";
      this.stateT = null;
      this.stateD = null;
      this.stateRY = null;
    },

    handleOK() {

      console.log(this.textT.length);

      this.handleSubmit();
    },

    handleSubmit() {
      this.$emit(
        "deleteMotionPicture",
        this.id,
        this.textT,
        this.textD,
        this.textRY
      );

      this.$nextTick(() => {
        this.$bvModal.hide("delete-modal");
      });
    },

  },

  data() {
    return {
      modalShow: this.showModal,
      id: Number,
      textT: "",
      textD: "",
      textRY: "",
      stateT: null,
      stateD: null,
      stateRY: null,
    };
  },

  created() {
    console.log("Created DeleteModule");
    console.log("modalShow = " + this.modalShow);
  },
};
</script>

<style scoped></style>
