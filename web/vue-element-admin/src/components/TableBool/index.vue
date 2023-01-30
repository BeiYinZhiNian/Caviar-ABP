<template>
  <div>
    <el-tag v-if="flag" type="success">是</el-tag>
    <el-tag v-if="!flag" type="danger">否</el-tag>
  </div>
</template>
<script>
export default {
  props: {
    flag: {
      type: Boolean,
      default: true
    }
  }
}
</script>
