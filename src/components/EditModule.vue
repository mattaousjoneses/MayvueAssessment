<template>
  <div>
    <b-modal
      id="edit-modal"
      header-bg-variant="info"
      body-text-variant="dark"
      class="edit"
      size="lg"
      title="Edit Motion Picture"
      no-stacking
      v-model="modalShow"
      @hidden="resetModal"
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
  name: "EditModule",
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
    showThatEditModal(id, textT, textD, textRY) {
      console.log("edit called");
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

    handleOK(bvModalEvt) {
      bvModalEvt.preventDefault();

      console.log(this.textT.length);

      this.handleSubmit();
    },

    handleSubmit() {
      if (!this.checkValidityEdit()) {
        return;
      }

      this.$emit(
        "editMotionPicture",
        this.id,
        this.textT,
        this.textD,
        this.textRY
      );

      this.$nextTick(() => {
        this.$bvModal.hide("edit-modal");
      });
    },

    checkValidityEdit() {
      this.stateT = 0 < this.textT.length && this.textT.length <= 50;
      this.stateD = this.textD.length <= 500;
      this.stateRY = /^\d{4}$/.test(this.textRY);

      return this.stateT && this.stateD && this.stateRY;
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
    console.log("Created Edit Module");
    console.log("modalShow = " + this.modalShow);
  },
};
</script>

<style scoped></style>
