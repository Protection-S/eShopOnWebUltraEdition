<template>
  <div>
    <form @submit.prevent="deleteUser">
      <div>
        <h1>Delete User</h1>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" @click="closeForm">
          Cancel
        </button>
        <button type="submit" class="btn btn-primary">DELETE</button>
      </div>
    </form>
  </div>
</template>

<script>
import axios from "axios";

export default {
  props: {
    userId: {
      type: String,
      required: true,
    },
  },
  data() {
    return {
    };
  },
  methods: {

    async deleteUser() {
      try {
        await axios.delete(
          `https://localhost:5099/api/User/${this.userId}`
        );
        alert("User deleted");
        this.closeForm();
      } catch (error) {
        console.error("Ошибка удаления:", error);
        alert("Ошибка удаления, братан, надо что-то делать");
      }
    },
    closeForm() {
      this.$emit("close");
    },
  },
};
</script>
