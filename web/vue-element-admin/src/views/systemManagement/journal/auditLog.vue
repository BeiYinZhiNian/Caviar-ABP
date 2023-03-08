<template>
  <div>
    <el-form ref="form" :model="selectData" inline>
      <el-form-item label="操作人">
        <el-input v-model="selectData.key" maxlength="20" placeholder="请输入操作人账号/名称" show-word-limit />
      </el-form-item>
      <el-form-item label="操作结果">
        <el-select v-model="selectData.result" clearable placeholder="请选择">
          <el-option label="成功" :value="true" />
          <el-option label="失败" :value="false" />
        </el-select>
      </el-form-item>
      <el-form-item label="操作时间">
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
        <el-table-column :show-overflow-tooltip="true" prop="phoneNumber" label="操作账号" />
        <el-table-column :show-overflow-tooltip="true" prop="browserInfo" label="浏览器" />
        <el-table-column :show-overflow-tooltip="true" prop="clientIpAddress" label="IP地址" />
        <el-table-column :show-overflow-tooltip="true" prop="result" label="操作结果">
          <template slot-scope="scope">
            <el-tag v-if="!scope.row.exception" type="success">成功</el-tag>
            <el-tag v-if="scope.row.exception" type="danger">失败</el-tag>
          </template>
        </el-table-column>
        <el-table-column :show-overflow-tooltip="true" prop="serviceName" label="请求服务" />
        <el-table-column :show-overflow-tooltip="true" prop="methodName" label="请求方法" />
        <el-table-column :show-overflow-tooltip="true" prop="executionTime" label="请求时间" />
        <el-table-column :show-overflow-tooltip="true" prop="executionDuration" label="运行时长" />
        <el-table-column :show-overflow-tooltip="true" label="操作" width="150">
          <template slot-scope="scope">
            <el-button
              size="mini"
              type="primary"
              @click="$refs.auditDetails.setFormData(scope.row)"
            >详情</el-button>
          </template>
        </el-table-column>
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
    <auditDetails ref="auditDetails" />
  </div>
</template>
<script>
import { getAllAuditLog } from '@/api/journal'
import auditDetails from '@/views/systemManagement/journal/auditDetails.vue'
export default {
  components: { auditDetails },
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
      getAllAuditLog(selectData).then(response => {
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
