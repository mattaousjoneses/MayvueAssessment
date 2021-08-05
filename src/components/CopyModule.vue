<template>
  <div>
    <b-modal
      id="copy-modal"
      header-bg-variant="info"
      body-text-variant="dark"
      class="copy"
      size="lg"
      title="Copy Motion Picture"
      no-stacking
      v-model="modalShow"
      @hidden="resetModal"
      @ok="handleOK"
    >
      <b-container>
        <p>Are you sure you want to copy {{ textT }}?</p>
      </b-container>
    </b-modal>
  </div>
</template>

<script>
export default {
  name: "CopyModule",
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
    showThatCopyModal(id, textT, textD, textRY) {
      console.log("copy called");
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
        "copyMotionPicture",
        this.id,
        this.textT,
        this.textD,
        this.textRY
      );

      this.$nextTick(() => {
        this.$bvModal.hide("copy-modal");
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
    console.log("Created CopyModule");
    console.log("modalShow = " + this.modalShow);
  },
};
</script>

<style scoped></style>
