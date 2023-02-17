<template>
  <div>
    <el-form ref="form" :model="selectData" inline>
      <el-form-item label="登录账号">
        <el-input v-model="selectData.key" maxlength="20" placeholder="请输入登录账号" show-word-limit />
      </el-form-item>
      <el-form-item label="登录结果">
        <el-select v-model="selectData.loginResult" clearable placeholder="请选择">
          <el-option label="登录成功" :value="true" />
          <el-option label="登录失败" :value="false" />
        </el-select>
      </el-form-item>
      <el-form-item label="登录时间">
        <el-date-picker
          v-model="selectData.time"
          type="datetimerange"
          range-separator="至"
          start-placeholder="开始日期"
          end-placeholder="结束日期"
        />
      </el-form-item>
      <el-form-item>
        <el-button type="success" @click="loadData()">查询</el-button>
      </el-form-item>
    </el-form>
    <div>
      <el-table
        :data="tableData.items"
        stripe
        border
        :header-cell-style="()=>{return 'text-align:center;background:#e1e4e5;color:#80878f'}"
        :cell-style="()=>{return 'text-align:center'}"
        style="width: 100%"
      >
        <el-table-column label="序号" type="index" width="80" align="center" />
        <el-table-column :show-overflow-tooltip="true" prop="userNameOrEmailAddress" label="登录账号" />
        <el-table-column :show-overflow-tooltip="true" prop="browserInfo" label="浏览器" />
        <el-table-column :show-overflow-tooltip="true" prop="result" label="登录结果">
          <template slot-scope="scope">
            <el-tag v-if="scope.row.result == 1" type="success">登录成功</el-tag>
            <el-tag v-if="scope.row.result != 1" type="danger">登录失败</el-tag>
          </template>
        </el-table-column>
        <el-table-column :show-overflow-tooltip="true" prop="resultMsg" label="登录信息" />
        <el-table-column :show-overflow-tooltip="true" prop="creationTime" label="登录时间" />
      </el-table>
    </div>
    <div>
      <el-pagination
        background
        layout="total, sizes, prev, pager, next, jumper"
        :current-page.sync="selectData.skipCount"
        :total="tableData.totalCount"
        :page-size="selectData.maxResultCount"
        @size-change="handleSizeChange"
        @current-change="handleCurrentChange"
      />
    </div>
  </div>
</template>
<script>
import { getAllUserLoginLog } from '@/api/journal'
export default {
  data() {
    return {
      loading: false,
      tableData: {},
      rolesOption: [],
      selectData: {
        maxResultCount: 10,
        skipCount: 1
      }
    }
  },
  created() {
    this.loadData()
  },
  methods: {
    loadData(selectData) {
      this.loading = true
      if (!selectData) {
        selectData = this.selectData
      }
      getAllUserLoginLog(selectData).then(response => {
        this.tableData = response.result
      }).finally(() => {
        this.loading = false
      })
    },
    handleSizeChange(val) {
      this.selectData.maxResultCount = val
      this.loadData(this.selectData)
    },
    handleCurrentChange(val) {
      this.selectData.skipCount = val
      this.loadData(this.selectData)
    }
  }
}
</script>
