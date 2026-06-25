<script setup>
    import WelcomeItem from './E12WeatherForecastWelcomeItem.vue'
    import DocumentationIcon from '/src/components/icons/IconDocumentation.vue'
    import ToolingIcon from '/src/components/icons/IconTooling.vue'
    import EcosystemIcon from '/src/components/icons/IconEcosystem.vue'
    import CommunityIcon from '/src/components/icons/IconCommunity.vue'
    import SupportIcon from '/src/components/icons/IconSupport.vue'
</script>

<template>
    <WelcomeItem>
        <template #icon>
            <DocumentationIcon />
        </template>
        <template #heading>
            文档
        </template>
        Vue的 <a href="https://vuejs.org/" target="_blank" rel="noopener">官方文档</a> 提供了入门所需的所有信息。
    </WelcomeItem>

    <WelcomeItem>
        <template #icon>
            <ToolingIcon />
        </template>
        <template #heading>
            工具
        </template>
        Vue3是与 <a href="https://vitejs.dev/guide/features.html" target="_blank" rel="noopener">Vite</a> 捆绑在一起提供服务的。
        <br />更多说明请参见 <code>README.md</code>
    </WelcomeItem>

    <WelcomeItem>
        <template #icon>
            <EcosystemIcon />
        </template>
        <template #heading>
            生态系统
        </template>
        其他官网提供的工具和库：
        <a href="https://pinia.vuejs.org/" target="_blank" rel="noopener">Pinia</a>，
        <a href="https://router.vuejs.org/" target="_blank" rel="noopener">Vue Router</a>，
        <a href="https://test-utils.vuejs.org/" target="_blank" rel="noopener">Vue Test Utils</a>，和
        <a href="https://github.com/vuejs/devtools" target="_blank" rel="noopener">Vue Dev Tools</a>
        如果需要更多资源，建议访问 <a href="https://github.com/vuejs/awesome-vue" target="_blank" rel="noopener">Awesome Vue</a>
    </WelcomeItem>

    <WelcomeItem>
        <template #icon>
            <CommunityIcon />
        </template>
        <template #heading>
            社区
        </template>
        卡住了？可提交问题到
        <a href="https://chat.vuejs.org" target="_blank" rel="noopener">Vue Land</a> 官方服务器，或者提交问题到
        <a href="https://stackoverflow.com/questions/tagged/vue.js" target="_blank" rel="noopener">StackOverflow</a>
        建议订阅 <a href="https://news.vuejs.org" target="_blank" rel="noopener">邮件列表</a> 并关注官方
        <a href="https://twitter.com/vuejs" target="_blank" rel="noopener">@vuejs</a> 推特账户，以获取Vue的最新消息。
    </WelcomeItem>

    <WelcomeItem>
        <template #icon>
            <SupportIcon />
        </template>
        <template #heading>
            支持Vue
        </template>
        作为一个独立的项目，Vue的可持续性依赖于社区的支持。可以通过成为Vue的
        <a href="https://vuejs.org/sponsor/" target="_blank" rel="noopener">赞助商</a> 为Vue提供资金赞助。
    </WelcomeItem>
</template>
