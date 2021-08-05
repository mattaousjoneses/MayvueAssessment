<template>
  <div>
    <b-modal
      id="add-modal"
      header-bg-variant="info"
      body-text-variant="dark"
      class="add"
      size="lg"
      title="Add Motion Picture"
      no-stacking
      v-model="modalShow"
      @hidden="resetModal"
      @show="resetModal"
      @ok="handleOK"
    >
      <b-container>
        <b-row class="mb-1 text-center">
          <b-col cols="2"> Title </b-col>
          <b-col>
            <b-form-group
              invalid-feedback="Name must be between 1 and 50 characters."
            >
              <b-form-input
                v-model="textT"
                placeholder="Enter Motion Picture Title"
                :state="stateT"
              ></b-form-input>
            </b-form-group>
          </b-col>
        </b-row>

        <b-row class="mb-1 text-center">
          <b-col cols="2"> Description </b-col>
          <b-col>
            <b-form-group
              invalid-feedback="Description must not be more than 500 characters."
            >
              <b-form-input
                v-model="textD"
                placeholder="Enter Motion Picture Description"
                :state="stateD"
              ></b-form-input>
            </b-form-group>
          </b-col>
        </b-row>

        <b-row class="mb-1 text-center">
          <b-col cols="2"> Release Year </b-col>
          <b-col>
            <b-form-group
              invalid-feedback="Release Year must be 4 digits and only numbers."
            >
              <b-form-input
                v-model="textRY"
                placeholder="Enter Motion Picture Release Year"
                :state="stateRY"
              ></b-form-input>
            </b-form-group>
          </b-col>
        </b-row>
      </b-container>
    </b-modal>
  </div>
</template>

<script>
export default {
  name: "AddModule",
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
    showThatAddModal() {
      console.log("function called");
      this.modalShow = true;
    },

    resetModal() {
      this.textT = "";
      this.textD = "";
      this.textRY = "";
      this.stateT = null;
      this.stateD = null;
      this.stateRY = null;
    },

    handleOK(bvModalEvt) {
      bvModalEvt.preventDefault();

      console.log(this.textT.length);

      this.handleSubmit();
    },

    handleSubmit() {
      if (!this.checkValidityAdd()) {
        return;
      }

      this.$emit("addMotionPicture", this.textT, this.textD, this.textRY);

      this.$nextTick(() => {
        this.$bvModal.hide("add-modal");
      });
    },

    checkValidityAdd() {
      this.stateT = 0 < this.textT.length && this.textT.length <= 50;
      this.stateD = this.textD.length <= 500;
      this.stateRY = /^\d{4}$/.test(this.textRY);

      return this.stateT && this.stateD && this.stateRY;
    },
  },

  data() {
    return {
      modalShow: this.showModal,
      textT: "",
      textD: "",
      textRY: "",
      stateT: null,
      stateD: null,
      stateRY: null,
    };
  },

  created() {
    console.log("Created Add Module");
    console.log("modalShow = " + this.modalShow);
  },
};
</script>

<style scoped></style>
